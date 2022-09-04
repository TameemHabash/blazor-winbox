window.WinBoxWindowManager =
{
    OpenWindow: (title, windowOptions) => {

        windowOptions.onclose = (force) => {
            if (force === true) {
                WinBoxWindowManager.CallMethodWithParameters(windowOptions.blazorWindowInstanceReference, windowOptions.xCloseHandlerName);
                return false;
            } else {
                WinBoxWindowManager.CallMethodWithParameters(windowOptions.blazorWindowInstanceReference, windowOptions.onCloseHandlerName);
                return true;
            }

        };
        let winBoxElement = new WinBox(windowOptions, title);
        return winBoxElement;
    },
    CallMethodWithParameters: (dotnetHelper, methodName, ...params) => {
        return dotnetHelper.invokeMethod(methodName, ...params);
    }
}