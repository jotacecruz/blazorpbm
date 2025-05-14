//window.checkAndRequestPermission = async function (name) {
//    try {
//        const status = await navigator.permissions.query({ name });

//        if (status.state === "granted" || status.state === "denied") {
//            return status.state;
//        }

//        // Only request if in "prompt" state and the name is supported
//        if (name === "geolocation") {
//            return new Promise((resolve, reject) => {
//                navigator.geolocation.getCurrentPosition(
//                    () => resolve("granted"),
//                    (err) => {
//                        console.warn("User denied geolocation:", err);
//                        resolve("denied");
//                    }
//                );
//            });
//        }

//        return "prompt"; // unsupported or can't request automatically
//    } catch (err) {
//        console.error("Permission check failed:", err);
//        return "error";
//    }
//};
