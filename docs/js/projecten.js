import { GITHUB_KEY } from "../config.js";

async function getGithubProjects() {
  // /user/repos geeft ALLE repo's van de eigenaar van het token, ook private
  const response = await fetch(
    "https://api.github.com/user/repos?visibility=all&affiliation=owner&per_page=100",
    {
      headers: {
        Authorization: `Bearer ${GITHUB_KEY}`,
        Accept: "application/vnd.github+json",
      },
    },
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
  try {
    const lijstElement = document.getElementById("project-list");

    const githubProjects = await getGithubProjects();
    const projectenStatus = document.getElementById("projecten-status");
    projectenStatus.style.display = "none";
    for (let i = 0; i < githubProjects.length; i++) {
      console.log(githubProjects[i].naam);

      lijstElement.insertAdjacentHTML(
        "beforeend",
        `
       <article class="project-card">
        <img src="img/PLACEHOLDER-IMAGE-1.png" alt="afbeelding van project ${githubProjects[i].naam}">
        <div>
          <h2>${githubProjects[i].naam}</h2>
          <p>${githubProjects[i].beschrijving}</p>
          <ul id="${githubProjects[i].naam}-tags">
          </ul>
          <div>
            <a href="${githubProjects[i].url}">View project</a>
          </div>
        </div>
      </article>
    `,
      );

      const tagsHTML = document.createElement("ul");
      tagsHTML.className = "project-tags";

      const label = document.createElement("li");
      label.textContent = "Tags:";
      tagsHTML.appendChild(label);

      githubProjects[i].topics.forEach((topic) => {
        const tag = document.createElement("li");
        tag.textContent = topic.toUpperCase();
        tagsHTML.appendChild(tag);
      });

      document
        .getElementById(`${githubProjects[i].naam}-tags`)
        .replaceWith(tagsHTML);
    }
  } catch (error) {
    console.error(error);
    projectenStatus.style.display = "";
    projectenStatus.textContent = "Er is iets mis gegaan met het laden van de projecten";
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
