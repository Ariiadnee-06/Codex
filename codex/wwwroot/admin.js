// Manejo de tabs
const tabButtons = document.querySelectorAll('.tab-button');
const adminContents = document.querySelectorAll('.admin-content');

tabButtons.forEach(button => {
    button.addEventListener('click', () => {
        // Desactivar todos los tabs
        tabButtons.forEach(btn => btn.classList.remove('active'));
        adminContents.forEach(content => content.classList.remove('active'));
        
        // Activar el tab seleccionado
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
const confirmDelete = document.getElementById('confirm-delete');

// Función para bloquear/desbloquear el scroll del body cuando se abren modales
function toggleBodyScroll(lock) {
    if (lock) {
        document.body.style.overflow = 'hidden';
    } else {
        document.body.style.overflow = '';
    }
}

// Abrir modal para agregar computador
openAddModal.addEventListener('click', () => {
    modalTitle.textContent = 'Agregar Nuevo Computador';
    computerForm.reset();
    document.getElementById('computer-id').value = '';
    computerModal.classList.remove('hidden');
    toggleBodyScroll(true);
    // Limpiar la vista previa de imagen
    updateImagePreview('');
});

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

// Permitir cerrar modales con Escape
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

// Datos de ejemplo para la demostración
const sampleComputers = [
    {
        id: 1,
        nombre: "Lenovo ThinkPad X1",
        descripcion: "Portátil de alto rendimiento para profesionales",
        tipo: "Portatil",
        categoria: "trabajo",
        precio: 1299.99,
        stock: 15,
        imagenURL: "Imagenes/computer-example.jpg",
        destacado: true
    },
    {
        id: 2,
        nombre: "Gaming Master Pro",
        descripcion: "PC Gaming de alta gama con RTX 3080",
        tipo: "PC",
        categoria: "juegos",
        precio: 2499.99,
        stock: 8,
        imagenURL: "Imagenes/computer-example2.jpg",
        destacado: false
    },
    {
        id: 3,
        nombre: "MacBook Pro M2",
        descripcion: "Portátil Apple con chip M2 para diseñadores",
        tipo: "Portatil",
        categoria: "diseno",
        precio: 1999.99,
        stock: 10,
        imagenURL: "Imagenes/computer-example3.jpg",
        destacado: true
    }
];

// Función para crear filas de la tabla
function createComputerRow(computer) {
    return `
        <tr>
            <td>${computer.id}</td>
            <td><img src="${computer.imagenURL}" alt="${computer.nombre}" class="table-image"></td>
            <td>${computer.nombre}</td>
            <td>${computer.tipo}</td>
            <td>${capitalizeFirstLetter(computer.categoria)}</td>
            <td>$${computer.precio.toFixed(2)}</td>
            <td>${computer.stock}</td>
            <td><span class="destacado-badge">${computer.destacado ? 'Sí' : 'No'}</span></td>
            <td class="actions-cell">
                <button class="action-button edit-button" data-id="${computer.id}">Editar</button>
                <button class="action-button delete-button" data-id="${computer.id}">Eliminar</button>
            </td>
        </tr>
    `;
}

// Función para cargar los datos en la tabla
function loadComputerTable(computers) {
    const tableBody = document.getElementById('computers-table-body');
    let html = '';
    
    computers.forEach(computer => {
        html += createComputerRow(computer);
    });
    
    tableBody.innerHTML = html;
    
    // Agregar event listeners para los botones de acciones
    document.querySelectorAll('.edit-button').forEach(button => {
        button.addEventListener('click', () => openEditModal(button.getAttribute('data-id')));
    });
    
    document.querySelectorAll('.delete-button').forEach(button => {
        button.addEventListener('click', () => openDeleteModal(button.getAttribute('data-id')));
    });
}

// Función para abrir modal de edición
function openEditModal(computerId) {
    const computer = sampleComputers.find(comp => comp.id == computerId);
    if (!computer) return;
    
    modalTitle.textContent = 'Editar Computador';
    
    // Llenar el formulario con los datos del computador
    document.getElementById('computer-id').value = computer.id;
    document.getElementById('nombre').value = computer.nombre;
    document.getElementById('descripcion').value = computer.descripcion;
    document.getElementById('tipo').value = computer.tipo;
    document.getElementById('categoria').value = computer.categoria;
    document.getElementById('precio').value = computer.precio;
    document.getElementById('stock').value = computer.stock;
    document.getElementById('imagen').value = computer.imagenURL;
    document.getElementById('destacado').checked = computer.destacado;
    
    // Mostrar vista previa de la imagen si existe
    updateImagePreview(computer.imagenURL);
    
    // Mostrar el modal
    computerModal.classList.remove('hidden');
    toggleBodyScroll(true);
}

// Función para abrir modal de confirmación de eliminación
function openDeleteModal(computerId) {
    confirmDelete.setAttribute('data-id', computerId);
    deleteModal.classList.remove('hidden');
    toggleBodyScroll(true);
}

// Event listener para el formulario
computerForm.addEventListener('submit', (e) => {
    e.preventDefault();
    
    // Recoger datos del formulario para simular grabación
    const formData = {
        id: document.getElementById('computer-id').value || Date.now(),
        nombre: document.getElementById('nombre').value,
        descripcion: document.getElementById('descripcion').value,
        tipo: document.getElementById('tipo').value,
        categoria: document.getElementById('categoria').value,
        precio: parseFloat(document.getElementById('precio').value),
        stock: parseInt(document.getElementById('stock').value),
        imagenURL: document.getElementById('imagen').value || 'Imagenes/computer-default.jpg',
        destacado: document.getElementById('destacado').checked
    };
    
    // Simular actualización del array de datos
    const existingIndex = sampleComputers.findIndex(c => c.id == formData.id);
    
    if (existingIndex >= 0) {
        // Actualizar computador existente
        sampleComputers[existingIndex] = { ...formData, id: parseInt(formData.id) };
    } else {
        // Agregar nuevo computador
        sampleComputers.push({ ...formData, id: sampleComputers.length + 1 });
    }
    
    // Cerrar el modal
    computerModal.classList.add('hidden');
    toggleBodyScroll(false);
    
    // Actualizar la tabla
    loadComputerTable(sampleComputers);
    
    // Alerta de éxito simulada
    alert('Computador guardado correctamente!');
});

// Event listener para confirmar eliminación
confirmDelete.addEventListener('click', () => {
    const computerId = confirmDelete.getAttribute('data-id');
    
    // Simular eliminación del computador
    const index = sampleComputers.findIndex(c => c.id == computerId);
    if (index !== -1) {
        sampleComputers.splice(index, 1);
    }
    
    // Cerrar el modal
    deleteModal.classList.add('hidden');
    toggleBodyScroll(false);
    
    // Actualizar la tabla
    loadComputerTable(sampleComputers);
    
    // Alerta de éxito simulada
    alert(`Computador con ID ${computerId} eliminado correctamente!`);
});

// Función para previsualización de imagen
function updateImagePreview(imageUrl) {
    const imagePreview = document.getElementById('image-preview');
    if (imageUrl) {
        imagePreview.innerHTML = `<img src="${imageUrl}" alt="Vista previa">`;
    } else {
        imagePreview.innerHTML = '';
    }
}

// Event listener para previsualizar la imagen al cambiar la URL
document.getElementById('imagen').addEventListener('input', (e) => {
    updateImagePreview(e.target.value);
});

// Manejar clics en modales para evitar cerrarlos accidentalmente
document.querySelectorAll('.modal_content').forEach(content => {
    content.addEventListener('click', (e) => {
        e.stopPropagation();
    });
});

// Permitir cerrar modales haciendo clic fuera del contenido
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

// Event listener para el botón de búsqueda
searchButton.addEventListener('click', applyFilters);

// Event listeners para los filtros de selección
categoryFilter.addEventListener('change', applyFilters);
typeFilter.addEventListener('change', applyFilters);

// Event listener para buscar al presionar Enter
searchInput.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') {
        applyFilters();
    }
});

// Función para aplicar filtros
function applyFilters() {
    const searchTerm = searchInput.value.toLowerCase();
    const categoryValue = categoryFilter.value;
    const typeValue = typeFilter.value;
    
    const filteredComputers = sampleComputers.filter(computer => {
        // Filtrar por término de búsqueda
        const matchesSearch = searchTerm === '' || computer.nombre.toLowerCase().includes(searchTerm);
        
        // Filtrar por categoría
        const matchesCategory = categoryValue === '' || computer.categoria === categoryValue;
        
        // Filtrar por tipo
        const matchesType = typeValue === '' || computer.tipo === typeValue;
        
        return matchesSearch && matchesCategory && matchesType;
    });
    
    loadComputerTable(filteredComputers);
}

// Paginación simulada
const prevPage = document.getElementById('prev-page');
const nextPage = document.getElementById('next-page');
const currentPageSpan = document.getElementById('current-page');
const totalPagesSpan = document.getElementById('total-pages');

// Event listeners para paginación
prevPage.addEventListener('click', () => {
    const currentPage = parseInt(currentPageSpan.textContent);
    if (currentPage > 1) {
        currentPageSpan.textContent = currentPage - 1;
        // Simular cambio de página
        window.scrollTo({ top: 0, behavior: 'smooth' });
    }
});

nextPage.addEventListener('click', () => {
    const currentPage = parseInt(currentPageSpan.textContent);
    const totalPages = parseInt(totalPagesSpan.textContent);
    if (currentPage < totalPages) {
        currentPageSpan.textContent = currentPage + 1;
        // Simular cambio de página
        window.scrollTo({ top: 0, behavior: 'smooth' });
    }
});

// Funciones utilitarias
function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

// Cargar la tabla al iniciar
document.addEventListener('DOMContentLoaded', () => {
    loadComputerTable(sampleComputers);
    
    // Configuración para la demostración
    totalPagesSpan.textContent = '3'; // Total de páginas ficticio
    
    // Ajustar clases en los badges de destacado
    document.querySelectorAll('.destacado-badge').forEach(badge => {
        if (badge.textContent === 'Sí') {
            badge.style.backgroundColor = '#4CAF50';
        } else {
            badge.style.backgroundColor = '#9E9E9E';
        }
    });
}); 