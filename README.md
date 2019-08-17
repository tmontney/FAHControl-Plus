# FAHControl-Plus
This is a helper client to extend FAHControl, from Folding@Home. This "helper" brings features FAHControl doesn't yet offer.

*  Timed snooze: You set the amount of minutes in settings, then click Snooze from tray. It'll automatically resume your slot(s) at the end of the snooze period.
*  "Conflicting applications": Most applicable example is games. Add in the full path of the game's EXE, and whenever that game (or app) launches, FAH will pause. FAH is resumed when all conflicting apps are not running.

By default, FAHControl+ doesn't control any slots until you list them. If you listed slot 01, snoozing or conflicting apps would only toggle slot 01. This can be configured in Settings, via your System Tray.

As of this time, FAHControl+ does **NOT** support authentication. FAHClient cannot be configured with a password.
