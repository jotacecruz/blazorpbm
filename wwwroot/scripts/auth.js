const CLIENT_ID = '326291637324-mh930u5g2179miaa1hc9e0lu5c3jql18.apps.googleusercontent.com';
const SCOPES = 'https://www.googleapis.com/auth/spreadsheets profile email';
let tokenClient;

async function getAccessToken() {
    return new Promise((resolve, reject) => {
        const tokenClient = google.accounts.oauth2.initTokenClient({
            client_id: CLIENT_ID,
            scope: SCOPES,
            prompt: 'select_account',
            callback: (response) => {
                if (response.error) {
                    reject(response.error);
                } else {
                    console.log(response);
                    document.cookie = `access_token=${response.access_token}; path=/; Secure; SameSite=Lax; max-age=3600`;
                    document.cookie = `expires_in=${response.expires_in}; path=/; Secure; SameSite=Lax; max-age=3600`;
                    document.cookie = `refresh_token=${response.refresh_token}; path=/; Secure; SameSite=Lax; max-age=3600`;
                    document.cookie = `token_type=${response.token_type}; path=/; Secure; SameSite=Lax; max-age=3600`;
                    resolve(JSON.stringify(response));
                }
            }
        });

        tokenClient.requestAccessToken();
    });
}

async function getCookie(name) {
    const cookies = document.cookie.split('; ');
    for (let cookie of cookies) {
        let [key, value] = cookie.split('=');
        if (key === name) return decodeURIComponent(value);
    }
    return null;
}

async function setCookie(name, value) {
    document.cookie = `${name}=${value}; path=/; Secure; SameSite=Lax; max-age=3600`;
}

async function validateAccessToken(accessToken) {
    console.log(accessToken);
    const response = await fetch(`https://www.googleapis.com/oauth2/v2/tokeninfo?access_token=${accessToken}`);
    if (response.ok == false)
        console.log(`error: ${response.status} ${response.statusText}`);
    return response.ok;
}