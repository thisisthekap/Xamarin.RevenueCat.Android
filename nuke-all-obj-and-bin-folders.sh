#!/bin/bash
cd "${0%/*}"
find . -type d -and \( -name "obj" -or -name "bin" -or -name "node_modules" \)
echo
echo "===================================="
echo
while true; do
    read -p "This is going nuke all the bin and object folders given above. Are you sure? " yn
    case $yn in
        [Yy]* ) echo "nuking..." \
            && find . -type d -and \( -name "obj" -or -name "bin" -or -name "node_modules" \) -exec rm -rf {} \; \
            && rm -f Mobile/Sepp.Mobile.Droid/Resources/values/strings.xml \
            && rm -f Mobile/Sepp.Mobile.Droid/Resources/values*/strings.xml \
            && rm -f Mobile/Sepp.Mobile.iOS/Info.plist \
            && rm -f Mobile/Sepp.Mobile.iOS/Resources/*.lproj/InfoPlist.strings \
            && echo "nuking done"; break;;
        [Nn]* ) echo "skipped nuking" && exit;;
        * ) echo "Please answer (y)es or (n)o.";;
    esac
done
