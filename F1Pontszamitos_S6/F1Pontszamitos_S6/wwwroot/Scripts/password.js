function passwordProtection() {
    const correctPassword = "titkos";
    const userPassword = prompt("Kérjük, adja meg a jelszót:");

    if (userPassword !== correctPassword) {
        alert("Helytelen jelszó! Az oldal nem töltődik be.");
        // Átirányítás másik oldalra
        window.location.href = "/";
    } else {
        alert("Helyes jelszó, folytatás...");//
    }
}