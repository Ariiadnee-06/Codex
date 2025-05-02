document.getElementById('show-login').onclick = () => {
    document.getElementById('login-form').classList.remove('hidden');
    document.getElementById('register-form').classList.add('hidden');
};

document.getElementById('show-register').onclick = () => {
    document.getElementById('register-form').classList.remove('hidden');
    document.getElementById('login-form').classList.add('hidden');
};

async function register() {
    const messageBox = document.getElementById('register-message');
    messageBox.style.display = "none";

    const data = {
        nombre: document.getElementById('register-nombre').value.trim(),
        apellido: document.getElementById('register-apellido').value.trim(),
        correo: document.getElementById('register-correo').value.trim(),
        contraseñaHash: document.getElementById('register-password').value.trim()
    };

    const response = await fetch('/api/auth/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    });

    let result;
    try {
        result = await response.json();
    } catch {
        result = { mensaje: "Error inesperado del servidor." };
    }

    messageBox.textContent = result.mensaje || result;
    messageBox.className = 'message ' + (response.ok ? 'success' : 'error');
    messageBox.style.display = "block";

    // ✅ Si fue exitoso, guarda sesión y redirige
    if (response.ok && result.usuario) {
        localStorage.setItem('usuario', JSON.stringify(result.usuario));
        console.log("🟢 Usuario registrado y logueado automáticamente:", result.usuario);
        setTimeout(() => {
            window.location.href = "/index.html";
        }, 1500);
    }
}



async function login() {
    const correo = document.getElementById('login-email').value.trim();
    const contraseña = document.getElementById('login-password').value.trim();

    if (!correo || !contraseña) {
        mostrarMensaje("login-message", "Por favor completa todos los campos.", false);
        return;
    }

    const data = {
        Correo: correo,
        ContraseñaHash: contraseña
    };

    console.log("📤 Enviando a backend:", data);

    try {
        const response = await fetch('/api/auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        let result;
        try {
            result = await response.json();
        } catch {
            result = { mensaje: "Respuesta inesperada del servidor." };
        }

        console.log("📥 Respuesta recibida del backend:", result);

        mostrarMensaje("login-message", result.mensaje || result, response.ok);

        if (response.ok && result.usuario) {
            // Guarda usuario exactamente como lo entrega el backend
            localStorage.setItem('usuario', JSON.stringify(result.usuario));
            console.log("✅ Usuario guardado en localStorage:", result.usuario);

            setTimeout(() => {
                window.location.href = "/index.html";
            }, 1500);
        }

    } catch (error) {
        console.error("❌ Error en login:", error);
        mostrarMensaje("login-message", "Error de conexión con el servidor.", false);
    }
}


function mostrarMensaje(id, mensaje, exito) {
    const msgBox = document.getElementById(id);
    msgBox.textContent = mensaje;
    msgBox.className = 'message ' + (exito ? 'success' : 'error');
    msgBox.style.display = "block";
}





// para el tab activo
document.getElementById('show-login').onclick = () => {
    document.getElementById('login-form').classList.add('active-form');
    document.getElementById('register-form').classList.remove('active-form');
    document.getElementById('show-login').classList.add('active-tab');
    document.getElementById('show-register').classList.remove('active-tab');
};

document.getElementById('show-register').onclick = () => {
    document.getElementById('register-form').classList.add('active-form');
    document.getElementById('login-form').classList.remove('active-form');
    document.getElementById('show-register').classList.add('active-tab');
    document.getElementById('show-login').classList.remove('active-tab');
};

