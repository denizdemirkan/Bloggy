var blogTitle;
var blogDescription;
var blogContent;

var buttonDark = document.getElementById("dark-theme");
var buttonLight = document.getElementById("light-theme");

// Event Listener
buttonDark.addEventListener("click", changeThemeDark);
buttonLight.addEventListener("click", changeThemeLight);

window.onload = function () {

    // Send Request
    fetch('https://localhost:7252/api/Blog/Get/1007')
        .then(response => response.json())
        .then(data => {

            // API'den dönen veriyi alırken yapmak istediğiniz işlemleri burada gerçekleştirin
            blogTitle = document.getElementById("blog-title");
            blogDescription = document.getElementById("blog-description");
            blogContent = document.getElementById("blog-content");
            
            blogTitle.textContent = data.title;
            blogDescription.textContent = data.description;

            // atob() is for decode BASE64 to raw string
            // use innerHTML function to inject data
            blogContent.innerHTML = decodeURIComponent(window.atob(data.text));

            pageTitle = document.getElementById("page-title");
            pageTitle.textContent = data.title;
        })
        .catch(error => {
            console.error('Error:', error);
        });
}

// Tema değiştirme fonksiyonu
function changeThemeDark() {
    var paragraph = document.getElementsByTagName("main")[0];
    var body = document.getElementsByTagName("body")[0];
    body.style.backgroundColor = "#393646";
    paragraph.style.color = "#F4EEE0";
}

function changeThemeLight() {
    var paragraph = document.getElementsByTagName("main")[0];
    var body = document.getElementsByTagName("body")[0];
    body.style.backgroundColor = "white";
    paragraph.style.color = "black";
}