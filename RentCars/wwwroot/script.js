const api = "https://localhost:7172/ReservaCar";

// listar carros disponiveis
async function mostrarCarros() {

    const resposta = await fetch(`${api}/carros`);
    const carros = await resposta.json();

    const lista = document.getElementById("listaCarros");
    lista.innerHTML = "";

    carros.forEach(carro => {
        lista.innerHTML += `
            <li>${carro.marca} ${carro.modelo} - ${carro.matricula}</li>
        `;
    });
}

// reservar carro
async function reservarCarro() {

    const marca = document.getElementById("Marca").value;
    const modelo = document.getElementById("Modelo").value;

    const resposta = await fetch(`${api}/reservar`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            marca: marca,
            modelo: modelo
        })
    });

    const mensagem = document.getElementById("mensagem");

    if (resposta.ok) {

        const data = await resposta.json();

        mensagem.innerText = data.mensagem ?? "Carro reservado com sucesso.";

        mostrarCarros(); // atualiza lista
    }
    else {
        mensagem.innerText = "Erro ao reservar carro.";
    }
}

// lista reservados
async function mostrarReservados() {

    const resposta = await fetch(`${api}/reservas`);
    const carros = await resposta.json();

    const lista = document.getElementById("listaReservados");
    lista.innerHTML = "";

    carros.forEach(carro => {
        lista.innerHTML += `
            <li>${carro.marca} ${carro.modelo} - ${carro.matricula}</li>
        `;
    });
}

async function adicionarCarro() {

    const marca = document.getElementById("addMarca").value;
    const modelo = document.getElementById("addModelo").value;
    const matricula = document.getElementById("addMatricula").value;

    const resposta = await fetch(`${api}/novo`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            marca: marca,
            modelo: modelo,
            matricula: matricula
        })
    });

    const mensagem = document.getElementById("mensagem");

    if (resposta.ok) {

        const data = await resposta.json();

        mensagem.innerText =
            data.mensagem ?? "Carro adicionado com sucesso.";

        // atualiza lista de carros
        mostrarCarros();
    }
    else {
        mensagem.innerText = "Erro ao adicionar carro.";
    }
}