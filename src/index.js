function addChore() {
    fetch('https://localhost:7195/Chores', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: {
            "description": "string",
            "complete": true,
            "updatedDate": "2023-05-22T01:29:23.161Z",
            "updatedBy": "string",
            "createdBy": "string",
            "createdDate": "2023-05-22T01:29:23.161Z"
        }
    })
    .then(response => response.json())
    .then(data => console.table(data));
}