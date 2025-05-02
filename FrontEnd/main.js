const navMenu = document.getElementById('nav_menu'),
      navToggle = document.getElementById('nav_toggle'),
      navClose = document.getElementById('nav_close');

if (navToggle) {
    navToggle.addEventListener('click', () => {
        navMenu.classList.add('show_menu');
    });
}

if (navClose) {
    navClose.addEventListener('click', () => {
        navMenu.classList.remove('show_menu');
    });
};

/*-----------Formulario----------------*/
const openFormBtn = document.getElementById('openNew')
const formModal = document.getElementById('form_modal');
const closeModal = document.getElementById('close_modal');

openFormBtn.addEventListener('click', (e) => {
    e.preventDefault(); 
    formModal.classList.remove('hidden');
});

closeModal.addEventListener('click', () => {
    formModal.classList.add('hidden');
});

const openOldFormBtn = document.getElementById('openOld')
const formOldModal = document.getElementById('form_modalOld');
const closeOldModal = document.getElementById('close_modalOld');

openOldFormBtn.addEventListener('click', (e) => {
    e.preventDefault(); 
    formOldModal.classList.remove('hidden');
});

closeOldModal.addEventListener('click', () => {
    formOldModal.classList.add('hidden');
});
