// Function to handle width-based display changes
function updateDisplay() {
    const width = window.innerWidth;

    console.log(width);
    if (width <= 890) {
        document.getElementById("navdisplay").style.display = "none";
        document.getElementById("bardisplay").style.display = "block";
        document.getElementById("logopos").style.bottom = "0px";
        console.log("Less");
    } else {
        document.getElementById("navdisplay").style.display = "block";
        document.getElementById("bardisplay").style.display = "none";
        document.getElementById("logopos").style.bottom = "30px";
        console.log("More");
    }
}

// Initial check when the script first runs
updateDisplay();

// Add event listener for window resize
window.addEventListener('resize', updateDisplay);



document.getElementById("Togglebutton").addEventListener("click", () => {
    console.log("togglecick");
})

document.getElementById("Togglebutton").onclick = () => {
    console.log("togglecick");
}







