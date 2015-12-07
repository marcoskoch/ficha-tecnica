var localStorageCommits = localStorage.getItem('latestCommits'.concat(id));

gitInfo.Links.forEach(function (link) {
    repos.push(link.URL)
})

if (localStorageCommits == null || localStorageCommits == '[]') {
    var totalCommits = 0;
    var days = [];

    $.get('https://api.github.com/users/' + username + '/events')
            .done(function (response) {
                response.forEach(function(r) {

                    if (r.type == 'PushEvent') {

                        if (!days.includes(r.created_at.slice(0, 10))) {
                            days.push(r.created_at.slice(0, 10));
                        }

                        totalCommits += r.payload.commits.length;

                        if (repos.includes('/' + r.repo.name + '/')) {
                            r.payload.commits.forEach(function (commit) { commitList.push(commit) })
                        }
                    }
                })
            }).always(function() {
                localStorage.setItem('avgCommits'.concat(id), totalCommits / days.length);
                localStorage.setItem('latestCommits'.concat(id), JSON.stringify(commitList));

                console.log(commitList);

                $('#media-commits').html(localStorage.getItem('avgCommits'.concat(id)));
                appendComments();
            })
}
else {
    console.log(localStorageCommits);
    commitList = JSON.parse(localStorageCommits);
    appendComments();
}

function appendComments() {
    commitList.sort(function (left, right) { return left.date < right.date })
    commitList = commitList.slice(0, 3);

    $('#commits').html('');

    commitList.forEach(function (commit) {
        $('#commits')
            .append($('<div class="bloco-commit">')
                .append($('<p>')
                    .append($('<a>').html(commit.sha.slice(0, 8)).attr('href', commit.url))
                    .append($('<p>').html(commit.message)))
        )
    })
}

setInterval(function () {
    localStorage.clear();
}, 1000 * 60 * 10)
