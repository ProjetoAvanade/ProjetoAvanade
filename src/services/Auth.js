export const UsuarioAutenticado = () => localStorage.getItem('usuario-login') != null;

export const parsejwt = () => {
    let base64 = localStorage.getItem("usuario-login").split('.')[1];

    return(JSON.parse(window.atob(base64)))
}