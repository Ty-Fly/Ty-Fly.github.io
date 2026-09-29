class Blog {
  constructor(titel, date, readTime, msg) {
    this.titel = titel;
    this.date = date;
    this.readTime = readTime;
    this.msg = msg;
  }
}

function loadBlogs() {
  let blogLijst = [];

  const datum = new Date();

  const blogStatus = document.getElementById("blog-status");

  blogStatus.style.display = "none";

  blogLijst.push(
    new Blog(
      "Blog post 1",
      datum.toISOString(),
      60,
      "Dit is een hoop tekst voor blogpost 1: \nIt is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
    ),
  );

  blogLijst.push(
    new Blog(
      "Blog post 2",
      datum.toISOString(),
      99,
      "Dit is een hoop tekst voor blogpost 2: \nIt is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
    ),
  );

  blogLijst.push(
    new Blog(
      "Blog post 3",
      datum.toISOString(),
      14,
      "Dit is een hoop tekst voor blogpost 3: \nIt is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like). ",
    ),
  );

  blogLijst.push(
    new Blog(
      "Blog post 4",
      datum.toISOString(),
      20,
      "Dit is een hoop tekst voor blogpost 4: \nIt is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like). ",
    ),
  );

  
  blogLijstHTML = document.getElementById("blog-list");

  for (let i = 0; i < blogLijst.length; i++) {

    blogLijstHTML.insertAdjacentHTML(
      "beforeend",
      `
        <article class="blog-card">
        <h2>${blogLijst[i].titel}</h2>
        <p>
          ${blogLijst[i].date.substr(0, blogLijst[i].date.indexOf("T"))}
          <span> - ${blogLijst[i].readTime} min read</span>
        </p>
        <p>
          ${blogLijst[i].msg}
        </p>
      </article>
        `,
    );
  }

}

loadBlogs();
