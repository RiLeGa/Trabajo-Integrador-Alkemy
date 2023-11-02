window.addEventListener('load', () => {

    let $ = (elemento) => document.querySelector(elemento)
    console.log("buscador vinculado");

    document.addEventListener("keyup", e => {
        console.log(e.target.value);
        if (e.target.matches("#inputSearch"))
            document.querySelectorAll(".listado").forEach(usuario => {
                usuario.textContent.toLowerCase().includes(e.target.value)
                    ? usuario.classList.remove('filtro')
                    : usuario.classList.add('filtro')
            })

    })
})