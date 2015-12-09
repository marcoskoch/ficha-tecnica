var localStorageCommits = localStorage.getItem('latestCommits'.concat(id));

gitInfo.Links.forEach(function (link) {
    repos.push(link.URL)
})

if (localStorageCommits == null || localStorageCommits == '[]') {
    var totalCommits = 0;
    var days = [];

    $.get('https://api.github.com/users/' + username + '/events')
            .done(function (response) {
                response.forEach(function (r) {
                    var lastDay = montaData(new Date(r.created_at));

                    if (r.type == 'PushEvent') {
                        if ($.inArray(lastDay, days)) {
                            days.push(lastDay);
                        }

                        totalCommits += r.payload.commits.length;

                        if($.inArray('/' + r.repo.name + '/',repos)){
                            r.payload.commits.forEach(function (commit) {
                                commit.url = r.repo.url.replace('https://api.github.com/repos/', gitInfo.URLBase + '/') + '/commit/' + commit.sha;
                                commit.date = lastDay;
                                commitList.push(commit);
                            })
                        }
                    }
                })
            }).always(function() {
                localStorage.setItem('avgCommits'.concat(id), totalCommits / days.length);
                localStorage.setItem('latestCommits'.concat(id), JSON.stringify(commitList));
            }).always(function () {
                appendAvgCommits();
                appendComments();
            })
}
else {
    commitList = JSON.parse(localStorageCommits);
    appendAvgCommits();
    appendComments();
}

function appendAvgCommits() {
    var avgCommits = localStorage.getItem('avgCommits'.concat(id)).slice(0, 4);
    $('#media-commits').html(avgCommits);
}


function appendComments() {
    commitList.sort(function (left, right) { return left.date < right.date })
    commitList = commitList.slice(0, 3);

    $('#commits').html('');

    commitList.forEach(function (commit) {
        $('#commit-list')
            .append($('<tr>')
                .append($('<td>').html(commit.date))
                .append($('<td>')
                    .append($('<a>').html(commit.sha.slice(0, 8)).attr('href', commit.url).attr('target', '_blank'))
                    .append($('<p>').text(commit.message)))
        )
    })
}

setInterval(function () {
    localStorage.clear();
}, 1000 * 60 * 10)
