async function getGithubProjects() {
  // /user/repos geeft ALLE repo's van de eigenaar van het token, ook private
  const response = await fetch(
    "https://api.github.com/users/Ty-Fly/repos?per_page=100",
    {},
  );

  if (!response.ok) {
    throw new Error(
      `Fout bij ophalen: ${response.status} ${response.statusText}`,
    );
  }

  const repos = await response.json();

  // Alleen repo's met het topic 'portfolio', en map de gegevens door naar een key/value pair lijst.
  const projects = repos
    .filter((repo) => repo.topics?.includes("portfolio"))
    .map((repo) => ({
      naam: repo.name,
      beschrijving: repo.description,
      topics: repo.topics.filter((t) => t !== "portfolio"),
      url: repo.html_url,
    }));

  return projects;
}

async function loadProjecten() {
  const projectenStatus = document.getElementById("projecten-status");
  const lijstElement = document.getElementById("project-list");

  try {
    const githubProjects = await getGithubProjects();

    if (githubProjects.length < 1) {
      projectenStatus.textContent = "Er zijn geen projecten gevonden";

      return;
    }

    projectenStatus.style.display = "none";

    githubProjects.forEach((project) => {
      const article = document.createElement("article");
      article.className = "project-card";

      const img = document.createElement("img");
      img.src = "img/PLACEHOLDER-IMAGE-1.png";
      img.alt = `afbeelding van het project ${project.naam}`;

      const innerDiv = document.createElement("div");

      const h2 = document.createElement("h2");
      h2.textContent = project.naam;

      const p = document.createElement("p");
      p.textContent = project.beschrijving;

      const tagsList = document.createElement("ul");
      tagsList.className = "project-tags";

      const label = document.createElement("li");
      label.textContent = "Tags:";
      tagsList.appendChild(label);

      project.topics.forEach((topic) => {
        const tag = document.createElement("li");
        tag.textContent = topic.toUpperCase();
        tagsList.appendChild(tag);
      });

      const linkDiv = document.createElement("div");
      const a = document.createElement("a");
      a.href = project.url;
      a.textContent = "View project";
      linkDiv.appendChild(a);

      innerDiv.appendChild(h2);
      innerDiv.appendChild(p);
      innerDiv.appendChild(tagsList);
      innerDiv.appendChild(linkDiv);

      article.appendChild(img);
      article.appendChild(innerDiv);

      lijstElement.appendChild(article);
    });
  } catch (error) {
    console.error(error);
    projectenStatus.style.display = "";
    projectenStatus.textContent =
      "Er is iets mis gegaan met het laden van de projecten";
  }
}

function searchProjects() {
  const input = document.getElementById("search");

  const filter = input.value.toUpperCase();

  const lijstElement = document.getElementById("project-list");

  const lijst = lijstElement.querySelectorAll(".project-card");

  for (let index = 0; index < lijst.length; index++) {
    const projectName = lijst[index].getElementsByTagName("H2")[0].innerText;

    



    if (projectName.toUpperCase().indexOf(filter) > -1) {
      lijst[index].style.display = "";
    } else {
      lijst[index].style.display = "none";
    }
  }
}

loadProjecten();

document.getElementById("search").addEventListener("input", searchProjects);
