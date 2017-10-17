<html>
<head><\head>
<body>
<h3>Opening a repository on the command line:</h3>
<p>"Shift+Right Click" on the folder that contains the ".git" file and on the prompt that pops up click "Open command window here" or "Git Bash Here"</p>
<hr>
<h3>How to create a new repository:</h3>
	<code>git init</code>
<hr>
<h3>How to add the remote repository to a new git:</h3>
<code>git remote add {RN} {URL}</code>
<p>
<strong>{RN}<strong>: What you want to refer to the origin as.
      Usually just call this origin unless origin already exists
<br>
{URL}: The url of the repository.
<br>
ex) <code>git remote add origin https://github.com/username/repo_name.git</code>
</p>
---------------------------------------------------------------------
How to clone a repository:
	git clone {URL} {DIRECTORY}
	
	{URL}: The url of the repository.

	{DIRECTORY}: The name of the folder that the repo will be cloned to

	ex) git clone https://github.com/username/repo_name.git repo_name
---------------------------------------------------------------------
How to stage files:
	git add {FILES}

	{FILES}: The files you wish to stage. Replace with "*" without the quotes to stage all files
	
	ex.1) git add *
	ex.2) git add file1.txt file2.bar "file three.foo"
---------------------------------------------------------------------
How to commit:
	git commit -m "{COMMIT MESSAGE}"

	Replace {COMMIT MESSAGE} with your commit message

	ex) git commit -m "Some files were changed"

	note: If you forgot to add "-m" to this command, see the section at the bottom of this file called, "So you fucked up?"
---------------------------------------------------------------------
How to push:
	git push {RN} {BRANCH}

	{RN}: The name of the remote repository (Usually origin)
	{BRANCH}: The name of the branch you want to push to the repository (Usually master)

	ex) git push origin master
---------------------------------------------------------------------
How to fetch:
	git fetch

	Fetch before pulling
---------------------------------------------------------------------
How to pull:
	git pull
	
	Pull before pushing
<\body>
</html>