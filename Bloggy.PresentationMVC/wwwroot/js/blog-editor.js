// Prevent Bootstrap dialog from blocking focusin
document.addEventListener('focusin', (e) => {
  if (e.target.closest(".tox-tinymce, .tox-tinymce-aux, .moxman-window, .tam-assetmanager-root") !== null) {
    e.stopImmediatePropagation();
  }
});

var blogJSON = new Object();

window.onload = function () {
  //Reset Editor
  var btnReset = document.getElementById('ResetBtn');
  btnReset.onclick = function () {
    tinyMCE.activeEditor.setContent('');
  }

  //Take Blog as HTML with images as binary 
  var btnSave = document.getElementById('SubmitBtn');
  btnSave.onclick = function () {
    blogJSON.text = btoa(encodeURIComponent(tinyMCE.activeEditor.getContent()));
    blogJSON.title = document.getElementById('blog-title').value;
    blogJSON.description = document.getElementById('blog-description').value;
    //var blogCategory = document.getElementById('blog-category').value;
    //var blogCoverImageBase64 = document.getElementById('SubmitBtn');
    blogJSON.categoryId = 1;
    blogJSON.authorId = 1;

    fetch('https://localhost:7252/api/Blog/Add', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(blogJSON)
    })
      .then(response => response.json())
      .then(data => {
        console.log('API yanıtı:', data);
        // API'den dönen veriyle yapmak istediğiniz işlemleri burada gerçekleştirin

        //Routing
      })
      .catch(error => {
        console.error('Hata:', error);
      });
  }
}