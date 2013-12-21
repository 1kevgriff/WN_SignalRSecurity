var viewModel = function () {
    var self = this;
    self.newNoteText = ko.observable("");
    self.noteList = ko.observableArray();

    self.submitNote = function () {
        if (self.connected == false) {
            alert("You are not connected to the server.");
        }
        $.connection.noteHub.server.addNote({
            content: self.newNoteText()
        }).done(function () {
            self.newNoteText("");
        }).fail(function (err) {
            alert(err.message);
        });
    };

    self.resetList = function () {
        $.connection.noteHub.server.getNotes().done(function (noteList) {
            ko.mapping.fromJS(noteList, {}, self.noteList);
        });
    };

    self.deleteAllNotes = function () {
        $.connection.noteHub.server.deleteAllNotes().done(function () {
            self.resetList();
        }).fail(function (err) {
            alert(err.message);
        })
    };

    self.init = function () {
        $.connection.hub.logging = true;

        $.connection.noteHub.client.incomingNote = function (newNote) {
            self.noteList.push(newNote);
        }

        $.connection.hub.url = "http://localhost:8888/signalr/";
        $.connection.hub.start().done(function () {
            self.connected = true;
            self.resetList();
        });
    };
};

var viewModelInstance = new viewModel();
viewModelInstance.init();
ko.applyBindings(viewModelInstance);