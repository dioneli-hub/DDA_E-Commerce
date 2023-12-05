function ShowUpdateQuantityButton(id, visible) {
    const updateQuantityButton = document.querySelector("button[data-cartItemId='" + id + "']");

    if (visible == true) {
        updateQuantityButton.style.display = "inline-block";
    }
    else {
        updateQuantityButton.style.display = "none";
    }
}