window.addEventListener('load', () => {
    if (token !== null && token !== undefined) {
        // Ahora puedes usar la variable token en tu script
        let authorizeToken = token.toString();
        //console.log(authorizeToken); // Debería mostrar el token en la consola del navegador
        sessionStorage.setItem("AuthToken", authorizeToken);
        // Obtén el token JWT desde sessionStorage
    } else {
        console.log("Ocurrió un error al recuperar el token");
    }
});



