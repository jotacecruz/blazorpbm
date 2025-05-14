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
                    document.cookie = `access_token=${response.access_token}; path=/; Secure`;
                    resolve(JSON.stringify(response));
                }
            }
        });

        tokenClient.requestAccessToken();
    });
}
