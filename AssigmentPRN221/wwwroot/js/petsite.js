function showUpdatePopup(id) {
    fetch(`/api/pets/${id}`)
        .then(response => response.json())
        .then(pet => {
            document.getElementById('updatePetId').value = pet.id;
            document.getElementById('updatePetName').value = pet.petName;
            document.getElementById('updatePetType').value = pet.petType;
            document.getElementById('updatePetBirthDate').value = pet.birthDate.split('T')[0];
            document.getElementById('updatePetGender').value = pet.petGender ?? "Unknown";
            document.getElementById('updatePetSpecialFeatures').value = pet.petSpecialFeatures ?? "Unknown";
            document.getElementById('updatePopup').style.display = 'block';
        });
}

function closeUpdatePopup() {
    document.getElementById('updatePopup').style.display = 'none';
}

function showDeletePopup(id) {
    document.getElementById('deletePetId').value = id;
    document.getElementById('deletePopup').style.display = 'block';
}

function closeDeletePopup() {
    document.getElementById('deletePopup').style.display = 'none';
}
