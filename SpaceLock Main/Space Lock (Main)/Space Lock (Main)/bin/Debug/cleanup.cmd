:: This script is part of Project SpaceLock - http://spacelock.madetokill.com
:: Cleans up remaining jpegs after ffmpeg has completed the work

:: author -- ideamonk@gmail.com

:: *** Warning, do not copy to other locations and execute over there.
::Doing so would recursively delete all jpg images under that path.

del WebInterface\Content\videos\*.jpg /F /S

:: Well thats it, this script is a one liner with 6 lines of remarks ;P