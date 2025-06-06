// Manejo de tabs
const tabButtons = document.querySelectorAll('.tab-button');
const adminContents = document.querySelectorAll('.admin-content');

/*-------------ABRIR Y CERRAR MODALES-------------*/

document.addEventListener("DOMContentLoaded", function () {
    const modal = document.getElementById("computer-modal");
    const openModalBtn = document.getElementById("openAddModal");
    const closeModalBtn = document.getElementById("close-computer-modal");

    if (openModalBtn && closeModalBtn && modal) {
        openModalBtn.addEventListener("click", function () {
            modal.classList.remove("hidden");
        });

        closeModalBtn.addEventListener("click", function () {
            modal.classList.add("hidden");
        });
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const editModal = document.getElementById("EditModal");
    const openEditModalBtn = document.getElementById("openEditModal");
    const closeEditModalBtn = document.getElementById("close-edit-modal");

    if (openEditModalBtn && closeEditModalBtn && editModal) {
        openEditModalBtn.addEventListener("click", function () {
            editModal.classList.remove("hidden");
        });

        closeEditModalBtn.addEventListener("click", function () {
            editModal.classList.add("hidden");
        });
    }
});


tabButtons.forEach(button => {
    button.addEventListener('click', () => {
        tabButtons.forEach(btn => btn.classList.remove('active'));
        adminContents.forEach(content => content.classList.remove('active'));

        button.classList.add('active');
        const tabId = button.getAttribute('data-tab');
        document.getElementById(`${tabId}-content`).classList.add('active');
    });
});

// Variables para el modal
const computerModal = document.getElementById('computer-modal');
const closeComputerModal = document.getElementById('close-computer-modal');
const openAddModal = document.getElementById('openAddModal');
const computerForm = document.getElementById('computer-form');
const modalTitle = document.getElementById('modal-title');

// Variables para el modal de confirmación de eliminación
const deleteModal = document.getElementById('delete-confirmation-modal');
const closeDeleteModal = document.getElementById('close-delete-modal');
const cancelDelete = document.getElementById('cancel-delete');

// Función para bloquear/desbloquear el scroll del body
function toggleBodyScroll(lock) {
    document.body.style.overflow = lock ? 'hidden' : '';
}

// Cerrar modales con Escape
document.addEventListener('keydown', (e) => {
    if (e.key === 'Escape') {
        if (!computerModal.classList.contains('hidden')) {
            computerModal.classList.add('hidden');
            toggleBodyScroll(false);
        }
        if (!deleteModal.classList.contains('hidden')) {
            deleteModal.classList.add('hidden');
            toggleBodyScroll(false);
        }
    }
});
// Previsualización de imagen
function updateImagePreview(imageUrl) {
    const imagePreview = document.getElementById('image-preview');
    imagePreview.innerHTML = imageUrl ? `<img src="${imageUrl}" alt="Vista previa">` : '';
}

document.getElementById('imagen').addEventListener('input', (e) => {
    updateImagePreview(e.target.value);
});

// Prevenir cierre de modales al hacer clic dentro del contenido
document.querySelectorAll('.modal_content').forEach(content => {
    content.addEventListener('click', (e) => e.stopPropagation());
});

// Cierre al hacer clic fuera del contenido
document.querySelectorAll('.modal').forEach(modal => {
    modal.addEventListener('click', () => {
        modal.classList.add('hidden');
        toggleBodyScroll(false);
    });
});


// Paginación (sin lógica de datos)
const prevPage = document.getElementById('prev-page');
const nextPage = document.getElementById('next-page');
const currentPageSpan = document.getElementById('current-page');
const totalPagesSpan = document.getElementById('total-pages');

prevPage.addEventListener('click', () => {
    const currentPage = parseInt(currentPageSpan.textContent);
    if (currentPage > 1) {
        currentPageSpan.textContent = currentPage - 1;
        window.scrollTo({ top: 0, behavior: 'smooth' });
    }
});

nextPage.addEventListener('click', () => {
    const currentPage = parseInt(currentPageSpan.textContent);
    const totalPages = parseInt(totalPagesSpan.textContent);
    if (currentPage < totalPages) {
        currentPageSpan.textContent = currentPage + 1;
        window.scrollTo({ top: 0, behavior: 'smooth' });
    }
});

// Capitalización para futura lógica
function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

// Cargar interfaz base
document.addEventListener('DOMContentLoaded', () => {
    totalPagesSpan.textContent = '1'; // Ficticio para la UI
});