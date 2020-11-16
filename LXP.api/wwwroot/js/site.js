const uri = 'api/employees';
let todos = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
    const firstName = document.getElementById('firstName').value;
    const lastName = document.getElementById('lastName').value;
    const hiredDate = document.getElementById('hiredDate').value;
    const taskList = document.getElementById('taskList').value;

    const item = {
        firstName: firstName,
        lastName: lastName,
        hiredDate: hiredDate,
        taskList: taskList,
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => {
            if (!response.ok) {
                alert('Unable to add item.' + response.status);
            }
            else {
                alert("Add successful");
                getItems();
            }
        })
        .catch(error => console.log('Unable to add item.', error));
}

function deleteItem() {
    var id = document.getElementById('deleteId').value;
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (!response.ok) {
                alert('Unable to delete item.' + response.status);
            }
            else {
                alert("delete successful");
                getItems()
            }
        })
        .catch(error => alert("Unable to delete item" + errors)/*error => console.error('Unable to delete item.', error)*/);
}


function updateItem() {
    const itemId = document.getElementById('update_id').value;
    const firstName = document.getElementById('update_firstName').value;
    const lastName = document.getElementById('update_lastName').value;
    const hiredDate = document.getElementById('update_hiredDate').value;
    const taskList = document.getElementById('update_taskList').value;
    
    const item_firstName = {
        op: "replace",
        path: "/firstName",
        value: firstName
    }

    const item_lastName = {
        op: "replace",
        path: "/lastName",
        value: lastName
    }

    const item_hiredDate = {
        op: "replace",
        path: "/hiredDate",
        value: hiredDate
    }

    const item_taskList = {
        op: "replace",
        path: "/taskList",
        value: taskList
    }

    var item = [];
    if (firstName.trim() != '') {
        item.push(item_firstName);
    }
    if (lastName.trim() != '') { item.push(item_lastName); }
    if (hiredDate.trim() != '') { item.push(item_hiredDate); }
    if (taskList.trim() != '') { item.push(item_taskList); }

    var a = JSON.stringify(item);
    if (a == []) {
        alert("A non - empty request body is required"); }
    fetch(`${uri}/${itemId}`, {
        method: 'PATCH',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => {
            if (!response.ok) {
                alert('Unable to delete item.' + response.status);
            }
            else {
                alert("update successful");
                getItems()
            }
        })
        .catch(error => console.error('Unable to update item.', error));
}


function _displayItems(data) {
    let btn = document.querySelector('#json');
    btn.textContent = "";
    //for (var i = 0; i < data.length; i++) {
    //    btn.textContent += JSON.stringify(data[i], null, '  ');
    //}
    data.forEach(item => {
        btn.textContent += JSON.stringify(item, null, '  ');
    })
}