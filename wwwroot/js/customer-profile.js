// Customer Profile Page JavaScript
document.addEventListener('DOMContentLoaded', function() {
    setupProfilePage();
    setupEventListeners();
    loadUserData();
});

// Setup profile page
function setupProfilePage() {
    // Initialize profile stats
    updateProfileStats();
    
    // Set active navigation
    setActiveNavigation();
}

// Setup event listeners
function setupEventListeners() {
    // Personal information edit button
    const editPersonalBtn = document.getElementById('editPersonalBtn');
    if (editPersonalBtn) {
        editPersonalBtn.addEventListener('click', () => toggleFormEditing('personalForm', 'personalFormActions'));
    }
    
    // Save buttons
    document.addEventListener('click', function(e) {
        if (e.target.classList.contains('save-btn')) {
            handleSaveChanges(e.target);
        }
        
        if (e.target.classList.contains('cancel-btn')) {
            handleCancelChanges(e.target);
        }
    });
    
    // Avatar edit button
    const editAvatarBtn = document.querySelector('.edit-avatar-btn');
    if (editAvatarBtn) {
        editAvatarBtn.addEventListener('click', handleAvatarEdit);
    }
    
    // Security buttons
    setupSecurityButtons();
    
    // Event tabs
    setupEventTabs();
    
    // View ticket buttons
    setupViewTicketButtons();
}

// Toggle form editing mode
function toggleFormEditing(formId, actionsId) {
    const form = document.getElementById(formId);
    const actions = document.getElementById(actionsId);
    const inputs = form.querySelectorAll('input, select, textarea');
    
    if (actions.style.display === 'none') {
        // Enable editing
        inputs.forEach(input => {
            input.disabled = false;
            input.classList.add('editing');
        });
        actions.style.display = 'flex';
    } else {
        // Disable editing
        inputs.forEach(input => {
            input.disabled = true;
            input.classList.remove('editing');
        });
        actions.style.display = 'none';
    }
}

// Handle save changes
function handleSaveChanges(saveBtn) {
    const form = saveBtn.closest('form');
    const formId = form.id;
    
    // Show loading state
    saveBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Saving...';
    saveBtn.disabled = true;
    
    // Simulate API call
    setTimeout(() => {
        // Update form state
        const inputs = form.querySelectorAll('input, select, textarea');
        inputs.forEach(input => {
            input.disabled = true;
            input.classList.remove('editing');
        });
        
        // Hide actions
        const actions = form.querySelector('.form-actions');
        if (actions) actions.style.display = 'none';
        
        // Reset button
        saveBtn.innerHTML = 'Save Changes';
        saveBtn.disabled = false;
        
        // Show success message
        showNotification('Changes saved successfully!', 'success');
        
        // Update profile data if personal info
        if (formId === 'personalForm') {
            updateProfileData();
        }
    }, 1500);
}

// Handle cancel changes
function handleCancelChanges(cancelBtn) {
    const form = cancelBtn.closest('form');
    
    // Reset form to original values
    form.reset();
    
    // Disable editing
    const inputs = form.querySelectorAll('input, select, textarea');
    inputs.forEach(input => {
        input.disabled = true;
        input.classList.remove('editing');
    });
    
    // Hide actions
    const actions = form.querySelector('.form-actions');
    if (actions) actions.style.display = 'none';
}

// Handle avatar edit
function handleAvatarEdit() {
    // Create file input
    const fileInput = document.createElement('input');
    fileInput.type = 'file';
    fileInput.accept = 'image/*';
    
    fileInput.addEventListener('change', function(e) {
        const file = e.target.files[0];
        if (file) {
            // Simulate avatar upload
            const reader = new FileReader();
            reader.onload = function(e) {
                // Update avatar (in real app, this would upload to server)
                showNotification('Avatar updated successfully!', 'success');
            };
            reader.readAsDataURL(file);
        }
    });
    
    fileInput.click();
}

// Setup security buttons
function setupSecurityButtons() {
    // Change password button
    const changePasswordBtn = document.querySelector('.security-item .btn');
    if (changePasswordBtn) {
        changePasswordBtn.addEventListener('click', handleChangePassword);
    }
    
    // 2FA button
    const twoFABtn = document.querySelector('.security-item:nth-child(2) .btn');
    if (twoFABtn) {
        twoFABtn.addEventListener('click', handleTwoFA);
    }
    
    // Login history button
    const loginHistoryBtn = document.querySelector('.security-item:nth-child(3) .btn');
    if (loginHistoryBtn) {
        loginHistoryBtn.addEventListener('click', handleLoginHistory);
    }
}

// Handle change password
function handleChangePassword() {
    // In real app, this would open a password change modal
    showNotification('Password change feature coming soon!', 'info');
}

// Handle two-factor authentication
function handleTwoFA() {
    // In real app, this would open 2FA setup
    showNotification('Two-factor authentication setup coming soon!', 'info');
}

// Handle login history
function handleLoginHistory() {
    // In real app, this would show login history
    showNotification('Login history feature coming soon!', 'info');
}

// Load user data
function loadUserData() {
    // In real app, this would fetch from API
    // For now, using mock data
    const userData = {
        firstName: 'John',
        lastName: 'Doe',
        email: 'john.doe@example.com',
        phone: '+1 (555) 123-4567',
        address: '123 Main Street, Apt 4B, New York, NY 10001',
        memberSince: 'January 2024',
        loyaltyPoints: 1250,
        totalEarned: 2100,
        totalRedeemed: 850
    };
    
    populateUserData(userData);
}

// Populate user data
function populateUserData(userData) {
    // Update profile header
    document.getElementById('userName').textContent = `${userData.firstName} ${userData.lastName}`;
    document.getElementById('userEmail').textContent = userData.email;
    document.getElementById('userMemberSince').textContent = `Member since ${userData.memberSince}`;
    
    // Update loyalty points
    document.getElementById('loyaltyPoints').textContent = userData.loyaltyPoints.toLocaleString();
    document.getElementById('currentPoints').textContent = userData.loyaltyPoints.toLocaleString();
    
    // Update form fields
    document.getElementById('firstName').value = userData.firstName;
    document.getElementById('lastName').value = userData.lastName;
    document.getElementById('email').value = userData.email;
    document.getElementById('phone').value = userData.phone;
    document.getElementById('address').value = userData.address;
}

// Update profile data
function updateProfileData() {
    const firstName = document.getElementById('firstName').value;
    const lastName = document.getElementById('lastName').value;
    
    // Update profile header
    document.getElementById('userName').textContent = `${firstName} ${lastName}`;
}

// Update profile stats
function updateProfileStats() {
    // In real app, this would calculate from user activity
    // For now, using static values
}

// Set active navigation
function setActiveNavigation() {
    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(link => {
        if (link.href.includes('MyProfile') || link.textContent.includes('My Profile')) {
            link.classList.add('active');
        } else {
            link.classList.remove('active');
        }
    });
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

// Setup event tabs functionality
function setupEventTabs() {
    const tabBtns = document.querySelectorAll('.tab-btn');
    const tabContents = document.querySelectorAll('.tab-content');
    
    tabBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            const targetTab = btn.getAttribute('data-tab');
            
            // Remove active class from all tabs and contents
            tabBtns.forEach(b => b.classList.remove('active'));
            tabContents.forEach(content => content.classList.remove('active'));
            
            // Add active class to clicked tab and corresponding content
            btn.classList.add('active');
            document.getElementById(`${targetTab}-tab`).classList.add('active');
        });
    });
}

// Setup view ticket buttons
function setupViewTicketButtons() {
    const viewTicketBtns = document.querySelectorAll('.view-ticket-btn');
    
    viewTicketBtns.forEach(btn => {
        btn.addEventListener('click', function(e) {
            e.preventDefault();
            const eventItem = this.closest('.event-item');
            const eventTitle = eventItem.querySelector('h4').textContent;
            const eventVenue = eventItem.querySelector('p').textContent;
            const ticketType = eventItem.querySelector('.ticket-type').textContent;
            
            // Show ticket details (in real app, this would open a modal or redirect)
            showNotification(`Opening E-Ticket for ${eventTitle} - ${ticketType}`, 'info');
            
            // Simulate ticket view
            setTimeout(() => {
                showNotification(`E-Ticket displayed for ${eventTitle}`, 'success');
            }, 1000);
        });
    });
}

console.log('Customer Profile Page Loaded Successfully!');
