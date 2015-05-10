# Accessible Output

Making applications which talk is very easy these days, due to APIs, like SAPI on Windows. However, having multiple applications speaking at once, using different voices and settings, can be distracting. This is the case for blind people who are using a screen reader, as well as some other talking program.

This library provides a simple API to speak using the screen reader's API if available, or SAPI otherwise.

You can either use a specific output class, or use the AutoOutput class. This will look for the first available output mode, and use that. So, if the JAWS screen reader is running, then it will speak using that. But if the user switches to the NVDA screen reader, the application will automatically start speaking via NVDA. Or if the user exits their screen reader, it will fall back to SAPI.

This library was inspired by the Python library with the same name, but was written from scratch.

