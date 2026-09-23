import { GITHUB_KEY } from '../config.js';

async function getGithubProjects() {
    try {
        // /user/repos geeft ALLE repo's van de eigenaar van het token, ook private
        const response = await fetch(
            'https://api.github.com/user/repos?visibility=all&affiliation=owner&per_page=100',
            {
                headers: {
                    'Authorization': `Bearer ${GITHUB_KEY}`,
                    'Accept': 'application/vnd.github+json'
                }
            }
        );

        if (!response.ok) {
            throw new Error(`Fout bij ophalen: ${response.status} ${response.statusText}`);
        }

        const repos = await response.json();

        // Alleen repo's met het topic 'portfolio', en map de gegevens door naar een key/value pair lijst.
        const projects = repos
            .filter(repo => repo.topics?.includes('portfolio'))
            .map(repo => ({
                naam: repo.name,
                beschrijving: repo.description,
                taal: repo.language,
                topics: repo.topics.filter(t => t !== 'portfolio'),
                prive: repo.private,
                url: repo.html_url,
                demo: repo.homepage,
                bijgewerkt: repo.pushed_at
            }));

        console.log('Projecten:', projects);

        console.log('yes')
        return projects;

    } catch (error) {
        console.error(error);
        return [];
    }
}

getGithubProjects();