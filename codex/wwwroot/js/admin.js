// Manejo de tabs
const tabButtons = document.querySelectorAll('.tab-button');
const adminContents = document.querySelectorAll('.admin-content');

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

// Función para bloquear/desbloquear scroll
function toggleBodyScroll(lock) {
    document.body.style.overflow = lock ? 'hidden' : '';
}

// Abrir modal para agregar computador
if (openAddModal) {
    openAddModal.addEventListener('click', (e) => {
        e.preventDefault();
        computerModal.classList.remove('hidden');
    });
}

if (closeDeleteModal) {
    closeDeleteModal.addEventListener('click', () => {
        computerModal.classList.add('hidden');
    });
}
// Cerrar modal de computador
closeComputerModal.addEventListener('click', () => {
    computerModal.classList.add('hidden');
    toggleBodyScroll(false);
});

// Cerrar modal de eliminación
closeDeleteModal.addEventListener('click', () => {
    deleteModal.classList.add('hidden');
    toggleBodyScroll(false);
});

// Cancelar eliminación
cancelDelete.addEventListener('click', () => {
    deleteModal.classList.add('hidden');
    toggleBodyScroll(false);
});

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

// Evitar cierre al hacer clic dentro del contenido del modal
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

// Filtros
const searchInput = document.getElementById('search-computer');
const categoryFilter = document.getElementById('filter-category');
const typeFilter = document.getElementById('filter-type');
const searchButton = document.querySelector('.search-button');

// Función para aplicar filtros (sin lógica de backend aún)
function applyFilters() {
    // Esta función solo está lista para integrarse a un backend
    // o recibir datos externos para filtrar.
}

// Eventos para filtros
searchButton.addEventListener('click', applyFilters);
categoryFilter.addEventListener('change', applyFilters);
typeFilter.addEventListener('change', applyFilters);
searchInput.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') applyFilters();
});
searchInput.addEventListener('input', applyFilters);

// Paginación simulada (navegación visual)
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

// Al cargar la página
document.addEventListener('DOMContentLoaded', () => {
    totalPagesSpan.textContent = '1'; // puedes actualizar dinámicamente según tu backend
});

// Utilidad: capitalizar primera letra (útil si se usa más adelante)
function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}



