// Sample event data - In a real application, this would come from an API
const eventsData = [
    {
        id: 1,
        title: "Rock Concert 2024",
        category: "concert",
        venue: "stadium",
        date: "2024-12-15",
        time: "8:00 PM",
        price: 89.99,
        image: "https://images.unsplash.com/photo-1493225457124-a3eb161ffa5f?w=400&h=200&fit=crop",
        location: "Central Stadium",
        description: "An electrifying night of rock music featuring top artists"
    },
    {
        id: 2,
        title: "Shakespeare in the Park",
        category: "theater",
        venue: "outdoor",
        date: "2024-12-18",
        time: "6:00 PM",
        price: 45.00,
        image: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=400&h=200&fit=crop",
        location: "Central Park",
        description: "Classic Shakespeare performed under the stars"
    },
    {
        id: 3,
        title: "Comedy Night",
        category: "cultural",
        venue: "theater",
        date: "2024-12-22",
        time: "9:00 PM",
        price: 35.99,
        image: "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b?w=400&h=200&fit=crop",
        location: "Comedy Club",
        description: "Laugh your night away with top comedians"
    },
    {
        id: 4,
        title: "Family Movie Night",
        category: "cultural",
        venue: "outdoor",
        date: "2024-12-25",
        time: "7:00 PM",
        price: 15.00,
        image: "https://images.unsplash.com/photo-1489599849927-2ee91cede3ba?w=400&h=200&fit=crop",
        location: "City Park",
        description: "Family-friendly movies under the open sky"
    },
    {
        id: 5,
        title: "Business Conference 2024",
        category: "cultural",
        venue: "concert-hall",
        date: "2024-12-30",
        time: "9:00 AM",
        price: 199.99,
        image: "https://images.unsplash.com/photo-1515187029135-18ee286d815b?w=400&h=200&fit=crop",
        location: "Convention Center",
        description: "Annual business conference with industry leaders"
    },
    {
        id: 6,
        title: "Jazz Festival",
        category: "concert",
        venue: "concert-hall",
        date: "2024-12-28",
        time: "7:00 PM",
        price: 75.00,
        image: "https://images.unsplash.com/photo-1415201364774-f6f0bb35f28f?w=400&h=200&fit=crop",
        location: "Jazz Hall",
        description: "Smooth jazz melodies in an intimate setting"
    },
    {
        id: 7,
        title: "Classical Symphony",
        category: "concert",
        venue: "concert-hall",
        date: "2024-12-19",
        time: "7:30 PM",
        price: 65.00,
        image: "https://images.unsplash.com/photo-1493225457124-a3eb161ffa5f?w=400&h=200&fit=crop",
        location: "Symphony Hall",
        description: "Beethoven's 9th Symphony performed by the city orchestra"
    },
    {
        id: 8,
        title: "Modern Art Exhibition",
        category: "cultural",
        venue: "theater",
        date: "2024-12-26",
        time: "10:00 AM",
        price: 25.00,
        image: "https://images.unsplash.com/photo-1541961017774-22349e4a1262?w=400&h=200&fit=crop",
        location: "Art Gallery",
        description: "Contemporary art showcase featuring local artists"
    },
    {
        id: 9,
        title: "Opera Night",
        category: "theater",
        venue: "theater",
        date: "2024-12-29",
        time: "8:00 PM",
        price: 120.00,
        image: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=400&h=200&fit=crop",
        location: "Opera House",
        description: "La Traviata performed by international opera stars"
    },
    {
        id: 10,
        title: "Dance Performance",
        category: "cultural",
        venue: "theater",
        date: "2024-12-31",
        time: "7:00 PM",
        price: 85.00,
        image: "https://images.unsplash.com/photo-1504609773096-104ff2c73ba4?w=400&h=200&fit=crop",
        location: "Dance Theater",
        description: "Contemporary dance showcase featuring local dance companies"
    },
    {
        id: 11,
        title: "Rock Band Live",
        category: "concert",
        venue: "stadium",
        date: "2025-01-05",
        time: "9:00 PM",
        price: 95.00,
        image: "https://images.unsplash.com/photo-1493225457124-a3eb161ffa5f?w=400&h=200&fit=crop",
        location: "Rock Arena",
        description: "High-energy rock concert with multiple bands"
    },
    {
        id: 12,
        title: "Film Festival",
        category: "cultural",
        venue: "outdoor",
        date: "2025-01-10",
        time: "6:00 PM",
        price: 40.00,
        image: "https://images.unsplash.com/photo-1489599849927-2ee91cede3ba?w=400&h=200&fit=crop",
        location: "City Square",
        description: "International film festival under the stars"
    }
];

// DOM elements
const searchInput = document.getElementById('searchInput');
const filterToggleBtn = document.getElementById('filterToggleBtn');
const filterChevron = document.getElementById('filterChevron');
const advancedFiltersPanel = document.getElementById('advancedFiltersPanel');
const clearFilters = document.getElementById('clearFilters');
const applyFilters = document.getElementById('applyFilters');
const activeFilters = document.getElementById('activeFilters');
const upcomingEventsContainer = document.getElementById('upcomingEvents');
const popularEventsContainer = document.getElementById('popularEvents');
const newsletterEmail = document.getElementById('newsletterEmail');

// Filter state
let currentFilters = {
    category: [],
    venue: [],
    date: [],
    price: []
};

// Initialize the application
document.addEventListener('DOMContentLoaded', function() {
    displayUpcomingEvents();
    displayPopularEvents();
    setupEventListeners();
    setupFilterSystem();
});

// Setup event listeners
function setupEventListeners() {
    // Search functionality
    if (searchInput) {
        searchInput.addEventListener('input', function() {
            const searchTerm = this.value.toLowerCase();
            filterEvents(searchTerm);
        });
    }

    // Newsletter subscription
    const newsletterForm = document.querySelector('.newsletter-form');
    if (newsletterForm) {
        newsletterForm.addEventListener('submit', function(e) {
            e.preventDefault();
            handleNewsletterSubscription();
        });
    }

    // Book button clicks
    document.addEventListener('click', function(e) {
        if (e.target.classList.contains('book-btn')) {
            handleBooking(e.target.dataset.eventId);
        }
    });
}

// Setup filter system
function setupFilterSystem() {
    // Quick filter pills
    const filterPills = document.querySelectorAll('.filter-pill');
    filterPills.forEach(pill => {
        pill.addEventListener('click', function() {
            // Remove active class from all pills
            filterPills.forEach(p => p.classList.remove('active'));
            // Add active class to clicked pill
            this.classList.add('active');
            
            const filterValue = this.dataset.filter;
            if (filterValue === 'all') {
                clearAllFilters();
            } else {
                applyQuickFilter(filterValue);
            }
        });
    });

    // Advanced filters toggle
    if (filterToggleBtn) {
        filterToggleBtn.addEventListener('click', function() {
            toggleAdvancedFilters();
        });
    }

    // Clear all filters
    if (clearFilters) {
        clearFilters.addEventListener('click', function() {
            clearAllFilters();
        });
    }

    // Apply filters
    if (applyFilters) {
        applyFilters.addEventListener('click', function() {
            applyCurrentFilters();
        });
    }

    // Auto-apply filters on checkbox change (but don't hide panel)
    if (advancedFiltersPanel) {
        const checkboxes = advancedFiltersPanel.querySelectorAll('input[type="checkbox"]');
        checkboxes.forEach(checkbox => {
            checkbox.addEventListener('change', function() {
                // Auto-apply filters after a short delay
                setTimeout(() => {
                    applyCurrentFiltersWithoutHiding();
                }, 300);
            });
        });
    }
}

// Apply current filters without hiding the panel (for checkbox changes)
function applyCurrentFiltersWithoutHiding() {
    if (!advancedFiltersPanel) return;
    
    // Get all checked checkboxes
    const checkedBoxes = advancedFiltersPanel.querySelectorAll('input[type="checkbox"]:checked');
    
    // Reset current filters
    currentFilters = {
        category: [],
        venue: [],
        date: [],
        price: []
    };

    // Collect checked filter values
    checkedBoxes.forEach(checkbox => {
        const filterType = checkbox.dataset.filter;
        const filterValue = checkbox.value;
        currentFilters[filterType].push(filterValue);
    });

    // Update active filters display
    updateActiveFiltersDisplay();
    
    // Apply filters to events
    applyFiltersToEvents();
}

// Apply current filters
function applyCurrentFilters() {
    if (!advancedFiltersPanel) return;
    
    // Get all checked checkboxes
    const checkedBoxes = advancedFiltersPanel.querySelectorAll('input[type="checkbox"]:checked');
    
    // Reset current filters
    currentFilters = {
        category: [],
        venue: [],
        date: [],
        price: []
    };

    // Collect checked filter values
    checkedBoxes.forEach(checkbox => {
        const filterType = checkbox.dataset.filter;
        const filterValue = checkbox.value;
        currentFilters[filterType].push(filterValue);
    });

    // Update active filters display
    updateActiveFiltersDisplay();
    
    // Apply filters to events
    applyFiltersToEvents();
    
    // Hide the advanced filters panel after applying
    hideAdvancedFilters();
}

// Toggle advanced filters panel
function toggleAdvancedFilters() {
    if (!advancedFiltersPanel) return;
    
    if (advancedFiltersPanel.classList.contains('show')) {
        // Hide the panel with animation
        hideAdvancedFilters();
    } else {
        // Show the panel with animation
        showAdvancedFilters();
    }
}

// Show advanced filters panel
function showAdvancedFilters() {
    if (!advancedFiltersPanel || !filterToggleBtn) return;
    
    advancedFiltersPanel.classList.remove('hide');
    advancedFiltersPanel.classList.add('show');
    filterToggleBtn.classList.add('expanded');
    filterToggleBtn.innerHTML = '<i class="fas fa-filter"></i> Hide Filters <i class="fas fa-chevron-up"></i>';
}

// Hide advanced filters panel
function hideAdvancedFilters() {
    if (!advancedFiltersPanel || !filterToggleBtn) return;
    
    advancedFiltersPanel.classList.remove('show');
    advancedFiltersPanel.classList.add('hide');
    filterToggleBtn.classList.remove('expanded');
    filterToggleBtn.innerHTML = '<i class="fas fa-filter"></i> More Filters <i class="fas fa-chevron-down"></i>';
    
    // Remove the hide class after animation completes
    setTimeout(() => {
        advancedFiltersPanel.classList.remove('hide');
    }, 300);
}

// Apply quick filter (category-based)
function applyQuickFilter(category) {
    // Reset all filters
    currentFilters = {
        category: [category],
        venue: [],
        date: [],
        price: []
    };
    
    // Uncheck all advanced filter checkboxes
    if (advancedFiltersPanel) {
        const checkboxes = advancedFiltersPanel.querySelectorAll('input[type="checkbox"]');
        checkboxes.forEach(checkbox => {
            checkbox.checked = false;
        });
    }
    
    // Apply filters to events
    applyFiltersToEvents();
}

// Clear all filters
function clearAllFilters() {
    // Uncheck all checkboxes
    if (advancedFiltersPanel) {
        const checkboxes = advancedFiltersPanel.querySelectorAll('input[type="checkbox"]');
        checkboxes.forEach(checkbox => {
            checkbox.checked = false;
        });
    }

    // Reset filter state
    currentFilters = {
        category: [],
        venue: [],
        date: [],
        price: []
    };

    // Reset quick filter pills
    const filterPills = document.querySelectorAll('.filter-pill');
    filterPills.forEach(pill => pill.classList.remove('active'));
    const allPill = document.querySelector('[data-filter="all"]');
    if (allPill) allPill.classList.add('active');

    // Update active filters display
    updateActiveFiltersDisplay();
    
    // Reset events display
    displayUpcomingEvents();
    displayPopularEvents();
}

// Update active filters display
function updateActiveFiltersDisplay() {
    if (!activeFilters) return;
    
    activeFilters.innerHTML = '';
    
    let hasActiveFilters = false;
    
    Object.entries(currentFilters).forEach(([filterType, values]) => {
        // Skip category filters - don't show chips for them
        if (filterType === 'category') return;
        
        values.forEach(value => {
            hasActiveFilters = true;
            const filterTag = createFilterTag(filterType, value);
            activeFilters.appendChild(filterTag);
        });
    });
    
    // Show/hide active filters section
    if (hasActiveFilters) {
        activeFilters.classList.add('show');
    } else {
        activeFilters.classList.remove('show');
    }
}

// Create filter tag element
function createFilterTag(filterType, value) {
    const tag = document.createElement('div');
    tag.className = 'filter-tag';
    
    const label = getFilterLabel(filterType, value);
    tag.innerHTML = `
        <span>${label}</span>
        <button class="remove-filter" data-filter-type="${filterType}" data-filter-value="${value}">
            <i class="fas fa-times"></i>
        </button>
    `;
    
    // Add remove functionality
    const removeBtn = tag.querySelector('.remove-filter');
    removeBtn.addEventListener('click', function() {
        removeFilter(filterType, value);
    });
    
    return tag;
}

// Get human-readable filter label
function getFilterLabel(filterType, value) {
    const labels = {
        category: {
            'concert': 'Concerts',
            'theater': 'Theatre',
            'cultural': 'Cultural Events'
        },
        venue: {
            'stadium': 'Stadium',
            'theater': 'Theater',
            'concert-hall': 'Concert Hall',
            'outdoor': 'Outdoor'
        },
        date: {
            'today': 'Today',
            'tomorrow': 'Tomorrow',
            'this-week': 'This Week',
            'this-month': 'This Month'
        },
        price: {
            '0-50': '$0 - $50',
            '50-100': '$50 - $100',
            '100-200': '$100 - $200',
            '200+': '$200+'
        }
    };
    
    return labels[filterType][value] || value;
}

// Remove individual filter
function removeFilter(filterType, value) {
    const index = currentFilters[filterType].indexOf(value);
    if (index > -1) {
        currentFilters[filterType].splice(index, 1);
        
        // Uncheck corresponding checkbox
        if (advancedFiltersPanel) {
            const checkbox = advancedFiltersPanel.querySelector(`input[value="${value}"][data-filter="${filterType}"]`);
            if (checkbox) {
                checkbox.checked = false;
            }
        }
        
        // Update display
        updateActiveFiltersDisplay();
        applyFiltersToEvents();
    }
}

// Apply filters to events
function applyFiltersToEvents() {
    let filteredEvents = eventsData;
    
    // Apply category filter
    if (currentFilters.category.length > 0) {
        filteredEvents = filteredEvents.filter(event => 
            currentFilters.category.includes(event.category)
        );
    }
    
    // Apply venue filter
    if (currentFilters.venue.length > 0) {
        filteredEvents = filteredEvents.filter(event => 
            currentFilters.venue.includes(event.venue)
        );
    }
    
    // Apply date filter
    if (currentFilters.date.length > 0) {
        filteredEvents = filteredEvents.filter(event => {
            const eventDate = new Date(event.date);
            const today = new Date();
            
            return currentFilters.date.some(dateFilter => {
                switch(dateFilter) {
                    case 'today':
                        return eventDate.toDateString() === today.toDateString();
                    case 'tomorrow':
                        const tomorrow = new Date(today);
                        tomorrow.setDate(tomorrow.getDate() + 1);
                        return eventDate.toDateString() === tomorrow.toDateString();
                    case 'this-week':
                        const weekFromNow = new Date(today);
                        weekFromNow.setDate(weekFromNow.getDate() + 7);
                        return eventDate >= today && eventDate <= weekFromNow;
                    case 'this-month':
                        return eventDate.getMonth() === today.getMonth() && 
                               eventDate.getFullYear() === today.getFullYear();
                    default:
                        return true;
                }
            });
        });
    }
    
    // Apply price filter
    if (currentFilters.price.length > 0) {
        filteredEvents = filteredEvents.filter(event => {
            return currentFilters.price.some(priceFilter => {
                const [min, max] = priceFilter.split('-').map(p => p === '+' ? Infinity : parseFloat(p));
                return event.price >= min && (max === Infinity ? true : event.price <= max);
            });
        });
    }
    
    // Update displays
    renderEvents(filteredEvents.slice(0, 6), upcomingEventsContainer);
    renderEvents(filteredEvents.slice(6, 12), popularEventsContainer);
}

// Display upcoming events
function displayUpcomingEvents() {
    const upcomingEvents = eventsData.slice(0, 6);
    renderEvents(upcomingEvents, upcomingEventsContainer);
}

// Display popular events
function displayPopularEvents() {
    const popularEvents = eventsData.slice(6, 12);
    renderEvents(popularEvents, popularEventsContainer);
}

// Render events in a container
function renderEvents(events, container) {
    if (!container) return;
    
    container.innerHTML = '';
    
    if (events.length === 0) {
        container.innerHTML = `
            <div style="grid-column: 1 / -1; text-align: center; padding: 2rem; color: #666;">
                <i class="fas fa-search" style="font-size: 3rem; margin-bottom: 1rem; opacity: 0.5;"></i>
                <h3>No events found</h3>
                <p>Try adjusting your filters or search terms</p>
            </div>
        `;
        return;
    }
    
    events.forEach(event => {
        const eventCard = createEventCard(event);
        container.appendChild(eventCard);
    });
}

// Create event card element
function createEventCard(event) {
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
            <div class="event-actions">
                <a href="/Home/EventDetail/${event.id}" class="btn btn-outline view-details-btn">View Details</a>
                <button class="book-btn" data-event-id="${event.id}">Book Now</button>
            </div>
        </div>
    `;
    return card;
}

// Format date for display
function formatDate(dateString) {
    const options = { 
        weekday: 'short', 
        year: 'numeric', 
        month: 'short', 
        day: 'numeric' 
    };
    return new Date(dateString).toLocaleDateString('en-US', options);
}

// Filter events based on search term
function filterEvents(searchTerm) {
    const filteredEvents = eventsData.filter(event => 
        event.title.toLowerCase().includes(searchTerm) ||
        event.category.toLowerCase().includes(searchTerm) ||
        event.location.toLowerCase().includes(searchTerm)
    );
    
    renderEvents(filteredEvents.slice(0, 6), upcomingEventsContainer);
    renderEvents(filteredEvents.slice(6, 12), popularEventsContainer);
}

// Handle booking
function handleBooking(eventId) {
    const event = eventsData.find(e => e.id == eventId);
    if (event) {
        // Redirect to event detail page using Home controller
        window.location.href = `/Home/EventDetail/${eventId}`;
    }
}

// Handle newsletter subscription
function handleNewsletterSubscription() {
    if (!newsletterEmail) return;
    
    const email = newsletterEmail.value.trim();
    
    if (!email) {
        alert('Please enter a valid email address.');
        return;
    }
    
    if (!isValidEmail(email)) {
        alert('Please enter a valid email address.');
        return;
    }
    
    // Simulate subscription
    alert(`Thank you for subscribing with: ${email}\n\nYou'll receive updates about new events and exclusive offers!`);
    newsletterEmail.value = '';
}

// Validate email format
function isValidEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

// Console log for development
console.log('ETicketing System Home Page Loaded Successfully!');
console.log('Available events:', eventsData.length);
