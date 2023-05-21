var getMostLikedBlogJson;
var getMostReadBlogJson;
var getLastPostJson;

async function getMostLikedBlog() {
    try {
        const response = await fetch("https://localhost:7252/api/Blog/GetMostLikedPost");
        getMostLikedBlogJson = await response.json();
        document.getElementById("mostLikedTitle").textContent=getMostLikedBlogJson['title'];
        document.getElementById("mostLikedDescription").textContent=getMostLikedBlogJson['description'];

      } catch (error) {
        console.error(error);
      }
  }

  async function getMostReadBlog() {
    try {
        const response = await fetch("https://localhost:7252/api/Blog/GetMostReadPost");
        getMostReadBlogJson = await response.json();
        document.getElementById("mostReadTitle").textContent=getMostReadBlogJson['title'];
        document.getElementById("mostReadDescription").textContent=getMostReadBlogJson['description'];
      } catch (error) {
        console.error(error);
      }
  }

  async function getLastBlog() {
    try {
        const response = await fetch("https://localhost:7252/api/Blog/GetLastPost");
        getLastPostJson = await response.json();
        document.getElementById("lastPostTitle").textContent=getLastPostJson['title'];
        document.getElementById("lastPostDescription").textContent=getLastPostJson['description'];
      } catch (error) {
        console.error(error);
      }
  }
