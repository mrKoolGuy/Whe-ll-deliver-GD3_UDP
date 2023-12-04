In an effort to keep the game in the main branch always in a working state, working with feature branches and pull requests is encouraged. The following steps outline how we want to work with branches, merges, and pull requests:
- pull the latest main
- create a new branch
- develop your feature and commit it to the new branch
- checkout main and pull
- checkout your feature branch again
- "git merge main --no-commit" this lets you test the merged result locally before commiting. You should have [UnityYamlMerge](https://docs.unity3d.com/Manual/SmartMerge.html) setup on your computer.
- push the branch
- create a new pull request in github for your new branch
- in the pull request you will be able to see what will be changed in main
- if you see something that should not be commited to the main branch in the changes, you can still add commits to fix that to the feature branch. It will automatically update in the pull request
- you can then ask teammembers to checkout the feature branch of the pull request and test the changes
- any possible issues can be corrected by further commits
- test if changed levels are playable
- if you are happy with the result, merge the pull request to get the changes in the main branch

This will insure that we always have a playable version of our game in the main branch.
