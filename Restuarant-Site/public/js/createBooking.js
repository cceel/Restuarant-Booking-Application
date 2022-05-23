﻿/****************************************************************************
     * Add a new TodoItem.
     *
     * 1) send an update to the DB
     * 2) if successful then add the item to the list
     ****************************************************************************/
function addNewBooking() {

    // Get the value from the Input field in the FORM
    let values = [];

    values.push(document.getElementById("locations").value.trim());
    values.push(document.getElementById("fname").value.trim());
    values.push(document.getElementById("lname").value.trim());
    values.push(document.getElementById("phonen").value.trim());
    values.push(document.getElementById("party").value.trim());
    values.push(document.getElementById("notes").value.trim());
    values.push(document.getElementById("info").value.trim());

    createBooking(values);
}

/****************************************************************************
 * CRUD functions calling the REST API
 ****************************************************************************/

function createBooking(values) {

    // Create a new JSON object for the new item with the status of NEW
    // Since the id is generated by the microservice, we will use -1 as a dummy
    // If the POST is successful the microservice will store the new item in the database
    // and returns a JSON via the response with the generated id for the new item
    const newBooking =
        {
            "location": values[0],
            "fname": values[1],
            "lname": values[2],
            "phonen": values[3],
            "party": values[4],
            "notes": values[5],
            "info": values[6],
            "status": "REQUESTED"
        };
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newBooking)
    };
    fetch('http://localhost:5023/booking', requestOptions)
        // get the JSON content from the response
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to create the Booking item")
                throw response.status;
            } else return response.json();
        })
}
