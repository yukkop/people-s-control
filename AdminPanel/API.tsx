import base64 from 'react-native-base64'

export function api<T>(
    url: string,
    method: string,
    username: string,
    password: string,
    body: any = null
): Promise<T> {
    let authorizationString = "Basic " + base64.encode(username + ":" + password);;

    let options;
    if (method == 'GET') {
        options = {
            method: method,
            mode: 'cors',
            headers: {
                'Authorization': authorizationString
            }
        }
    }
    else {
        options = {
            method: method,
            headers: {
                'Authorization': authorizationString,
                'HOST': 'localhost:44373',
                'Content-Type': 'application/json',
            },
            mode: 'cors',
            body: JSON.stringify(body),

        }
    }

    const a = fetch("https://localhost:44373/api/user/Authorization", {
        method: 'GET',
        mode: 'no-cors',
        headers: {
            'Authorization': authorizationString
        }
    })
        .then((response) => {
            alert(JSON.stringify(response));
            return response.json()
        })
        //If response is in json then in success
        .then((responseJson) => {
            //Success
            alert(JSON.stringify(responseJson));
            console.log(responseJson);
        })
        .catch((error) => {
            //Error
            alert(JSON.stringify(error));
            console.error(error);
            return error
        });

    console.log(a.then(response => alert(JSON.stringify(response))));
    return a
}

/*
// Consumer - consumer remains the same
api<{ title: string; message: string }>('v1/posts/1')
    .then(({ title, message }) => {
        console.log(title, message)
    })
    .catch(error => {
        // show error message 
    })
*/