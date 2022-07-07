# Jarvis
## Why?
After building & rebuilding my home lab out of necessity (or most often times boredum), I settled on a configuration that I've liked the most and wanted to automate the creation of users, groups, OUs, and group memberships to cut down on the tedious work. Also I just wanted an excuse to write something in C#. And, yes, I **was** watching a Marvel movie when I came up with the name. 

## How to use
Pretty straightforward - build the tool and give it the name of your domain as the only argument on the cli. Example: `Jarvis.exe evil.corp` and the tool will do the rest (it defaults to LDAP on 389 since it's a brand new DC without SSL implemented). Just make sure you're running under a user context with privileges to modify AD. Since this was intended to use after the domain controller role is configured on a Windows server, you'll likely already be running as the `DOMAIN\Administrator` account or a custom Domain Admin you created. 

## Future Work?
The tool is pretty crude (but effective... hopefully) so there isn't plans for much more dev work on this. **Maybe** I could be convinced to support importing a configuration file from something like a .csv, but if you're a JSON fan-person then you'll need to submit a PR because JSON is trash (fiteme).

## Shoutouts
I've read of lot of [@b33f](https://twitter.com/FuzzySec)'s [StandIn](https://github.com/FuzzySecurity/StandIn) code as a reference on how to do things with LDAP in C#. Highly recommend checking it out, it's a lifesaver when operating from an implant/Windows box.
