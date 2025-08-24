// Function to toggle between existing and new victim/suspect
function toggleFields(checkboxId, fieldsId, selectId) {
    const checkbox = document.getElementById(checkboxId);
    const fields = document.getElementById(fieldsId);
    const select = document.getElementById(selectId);

    checkbox.addEventListener('change', function () {
        if (this.checked) {
            fields.style.display = 'block';
            select.disabled = true;
            select.value = '';
        } else {
            fields.style.display = 'none';
            select.disabled = false;
        }
    });
}

// Initialize on page load
document.addEventListener('DOMContentLoaded', function () {
    toggleFields('createNewVictim', 'newVictimFields', 'existingVictimSelect');
    toggleFields('createNewSuspect', 'newSuspectFields', 'existingSuspectSelect');
});