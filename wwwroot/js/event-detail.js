// Event Detail Page JavaScript
document.addEventListener('DOMContentLoaded', function() {
    setupEventListeners();
    loadSimilarEvents();
});

// Setup event listeners
function setupEventListeners() {
    // Buy ticket buttons
    document.addEventListener('click', function(e) {
        if (e.target.classList.contains('buy-ticket-btn')) {
            const category = e.target.dataset.category;
            const price = parseFloat(e.target.dataset.price);
            openPurchaseModal(category, price);
        }
    });
    
    // Modal close button
    const closeModal = document.getElementById('closeModal');
    if (closeModal) {
        closeModal.addEventListener('click', closePurchaseModal);
    }
    
    // Modal overlay click to close
    const modalOverlay = document.getElementById('purchaseModal');
    if (modalOverlay) {
        modalOverlay.addEventListener('click', function(e) {
            if (e.target === modalOverlay) {
                closePurchaseModal();
            }
        });
    }
    
    // Ticket quantity change
    const ticketQuantity = document.getElementById('ticketQuantity');
    if (ticketQuantity) {
        ticketQuantity.addEventListener('change', updateTotalPrice);
    }
    
    // Purchase form submission
    const purchaseForm = document.querySelector('.purchase-form');
    if (purchaseForm) {
        purchaseForm.addEventListener('submit', handlePurchase);
    }
}

// Load similar events
function loadSimilarEvents() {
    // Mock similar events data
    const similarEvents = [
        {
            id: 2,
            title: "Classical Symphony Night",
            category: "Classical",
            date: new Date(Date.now() + 45 * 24 * 60 * 60 * 1000),
            time: "7:30 PM",
            location: "New York, NY",
            venue: "Carnegie Hall",
            price: 95,
            image: "https://images.unsplash.com/photo-1493225457124-a3eb161ffa5f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80"
        },
        {
            id: 3,
            title: "Jazz Night Live",
            category: "Jazz",
            date: new Date(Date.now() + 20 * 24 * 60 * 60 * 1000),
            time: "9:00 PM",
            location: "New York, NY",
            venue: "Blue Note Club",
            price: 45,
            image: "https://images.unsplash.com/photo-1415201364774-f6f0bb35f28f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80"
        }
    ];
    
    const container = document.getElementById('similarEvents');
    if (!container) return;
    
    container.innerHTML = '';
    
    if (similarEvents.length === 0) {
        container.innerHTML = `
            <div style="grid-column: 1 / -1; text-align: center; padding: 2rem; color: #666;">
                <p>No similar events found</p>
            </div>
        `;
        return;
    }
    
    similarEvents.forEach(event => {
        const eventCard = createSimilarEventCard(event);
        container.appendChild(eventCard);
    });
}

// Create similar event card
function createSimilarEventCard(event) {
    const card = document.createElement('div');
    card.className = 'event-card';
    card.innerHTML = `
        <img src="${event.image}" alt="${event.title}" class="event-image">
        <div class="event-content">
            <div class="event-category">${event.category.toUpperCase()}</div>
            <h3 class="event-title">${event.title}</h3>
            <div class="event-details">
                <span><i class="fas fa-calendar"></i> ${formatDate(event.date)}</span>
                <span><i class="fas fa-clock"></i> ${event.time}</span>
            </div>
            <div class="event-details">
                <span><i class="fas fa-map-marker-alt"></i> ${event.location}</span>
                <span><i class="fas fa-tag"></i> ${event.venue}</span>
            </div>
            <div class="event-price">$${event.price}</div>
            <a href="/Event/Detail/${event.id}" class="btn btn-outline">View Details</a>
        </div>
    `;
    return card;
}

// Open purchase modal
function openPurchaseModal(category, price) {
    const modal = document.getElementById('purchaseModal');
    const eventData = window.eventData;
    
    if (!eventData) return;
    
    // Set modal content
    document.getElementById('modalEventTitle').textContent = eventData.title;
    document.getElementById('modalTicketType').textContent = category.toUpperCase();
    document.getElementById('modalTicketPrice').textContent = `$${price}`;
    document.getElementById('basePrice').textContent = `$${price}`;
    
    // Update total
    updateTotalPrice();
    
    // Show modal
    modal.classList.add('show');
    document.body.style.overflow = 'hidden';
}

// Close purchase modal
function closePurchaseModal() {
    const modal = document.getElementById('purchaseModal');
    modal.classList.remove('show');
    document.body.style.overflow = 'auto';
    
    // Reset form
    const form = document.querySelector('.purchase-form');
    if (form) form.reset();
}

// Update total price
function updateTotalPrice() {
    const quantity = parseInt(document.getElementById('ticketQuantity').value);
    const basePrice = parseFloat(document.getElementById('basePrice').textContent.replace('$', ''));
    const total = basePrice * quantity;
    
    document.getElementById('quantityDisplay').textContent = quantity;
    document.getElementById('totalPrice').textContent = `$${total.toFixed(2)}`;
}

// Handle purchase submission
function handlePurchase(e) {
    e.preventDefault();
    
    const formData = new FormData(e.target);
    const quantity = document.getElementById('ticketQuantity').value;
    const total = document.getElementById('totalPrice').textContent;
    const eventData = window.eventData;
    const category = document.querySelector('.ticket-category-label').textContent;
    
    // Validate form
    const name = document.getElementById('customerName').value.trim();
    const email = document.getElementById('customerEmail').value.trim();
    const phone = document.getElementById('customerPhone').value.trim();
    
    if (!name || !email || !phone) {
        showNotification('Please fill in all required fields.', 'error');
        return;
    }
    
    if (!isValidEmail(email)) {
        showNotification('Please enter a valid email address.', 'error');
        return;
    }
    
    // Simulate purchase processing
    const purchaseBtn = document.querySelector('.purchase-btn');
    const originalText = purchaseBtn.innerHTML;
    
    purchaseBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Processing...';
    purchaseBtn.disabled = true;
    
    setTimeout(() => {
        // Success message
        showNotification(`🎉 Purchase Successful!\n\nEvent: ${eventData.title}\nCategory: ${category}\nQuantity: ${quantity}\nTotal: ${total}\n\nConfirmation has been sent to: ${email}\n\nThank you for your purchase!`, 'success');
        
        // Reset form and close modal
        closePurchaseModal();
        
        // Reset button
        purchaseBtn.innerHTML = originalText;
        purchaseBtn.disabled = false;
    }, 2000);
}

// Validate email format
function isValidEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

// Format date for display
function formatDate(date) {
    const options = { 
        weekday: 'long', 
        year: 'numeric', 
        month: 'long', 
        day: 'numeric' 
    };
    return new Date(date).toLocaleDateString('en-US', options);
}

// Show notification
function showNotification(message, type = 'info') {
    // Create notification element
    const notification = document.createElement('div');
    notification.className = `notification notification-${type}`;
    notification.innerHTML = `
        <div class="notification-content">
            <i class="fas fa-${type === 'success' ? 'check-circle' : type === 'error' ? 'exclamation-circle' : 'info-circle'}"></i>
            <span>${message}</span>
        </div>
        <button class="notification-close">
            <i class="fas fa-times"></i>
        </button>
    `;
    
    // Add to page
    document.body.appendChild(notification);
    
    // Show notification
    setTimeout(() => notification.classList.add('show'), 100);
    
    // Auto remove after 5 seconds
    setTimeout(() => {
        notification.classList.remove('show');
        setTimeout(() => notification.remove(), 300);
    }, 5000);
    
    // Close button functionality
    const closeBtn = notification.querySelector('.notification-close');
    closeBtn.addEventListener('click', () => {
        notification.classList.remove('show');
        setTimeout(() => notification.remove(), 300);
    });
}

// Add smooth scrolling for navigation
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});

// Add scroll effect to header
window.addEventListener('scroll', function() {
    const header = document.querySelector('.header');
    if (window.scrollY > 100) {
        header.style.background = 'rgba(102, 126, 234, 0.95)';
    } else {
        header.style.background = 'linear-gradient(135deg, #667eea 0%, #764ba2 100%)';
    }
});

console.log('Event Detail Page Loaded Successfully!');
