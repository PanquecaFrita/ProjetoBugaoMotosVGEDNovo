const menuItems = document.querySelectorAll('.menu-item');

menuItems.forEach(item => {
    item.addEventListener('click', () => {
        // Remove a classe "active" de todos
        menuItems.forEach(el => el.classList.remove('active'));
        // Adiciona ao item clicado
        item.classList.add('active');
    });
});

/* cadastro cliente */
document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const usuario = document.getElementById("usuario").value;
    const senha = document.getElementById("senha").value;

    // Simula��o de login
    if (usuario === "admin" && senha === "1234") {
        alert("Login bem-sucedido!");
    } else {
        alert("Usu�rio ou senha inv�lidos.");
    }
});

/* cadastro fornecedor */
document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const usuario = document.getElementById("usuario").value;
    const senha = document.getElementById("senha").value;

    // Simula��o de login
    if (usuario === "admin" && senha === "1234") {
        alert("Login bem-sucedido!");
    } else {
        alert("Usu�rio ou senha inv�lidos.");
    }
});

/* Cadastro Produto */
document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const usuario = document.getElementById("usuario").value;
    const senha = document.getElementById("senha").value;

    // Simula��o de login
    if (usuario === "admin" && senha === "1234") {
        alert("Login bem-sucedido!");
    } else {
        alert("Usu�rio ou senha inv�lidos.");
    }
});

/* Cadastro Servi�o */
document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();

    const usuario = document.getElementById("usuario").value;
    const senha = document.getElementById("senha").value;

    // Simula��o de login
    if (usuario === "admin" && senha === "1234") {
        alert("Login bem-sucedido!");
    } else {
        alert("Usu�rio ou senha inv�lidos.");
    }
});
/*hora*/
<script>
    function updateClock() {
        const now = new Date();
    const hours = String(now.getHours()).padStart(2, '0');
    const minutes = String(now.getMinutes()).padStart(2, '0');
    const seconds = String(now.getSeconds()).padStart(2, '0');
    document.getElementById('clock').textContent = `${hours}:${minutes}:${seconds}`;
    }
    setInterval(updateClock, 1000);
    updateClock();
</script>