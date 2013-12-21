var viewModel = function () {
    var self = this;
    self.newNoteText = ko.observable("");
    self.noteList = ko.observableArray();

    self.submitNote = function () {
        if (self.connected == false) {
            alert("You are not connected to the server.");
        }

        self.noteHub.invoke('addNote', {
            content: self.newNoteText()
        }).done(function () {
            self.newNoteText("");
        }).fail(function (err) {
            alert(err.message);
        });
    };

    self.resetList = function () {
        self.noteHub.invoke('getNotes').done(function (noteList) {
            ko.mapping.fromJS(noteList, {}, self.noteList);
        });
    };

    self.deleteAllNotes = function () {
        self.noteHub.invoke('deleteAllNotes').done(function () {
            self.resetList();
        }).fail(function (err) {
            alert(err.message);
        })
    };

    self.init = function () {
        var connection = $.hubConnection("/signalr");
        self.noteHub = connection.createHubProxy('noteHub');

        connection.logging = true;

        self.noteHub.on('incomingNote', function (newNote) {
            self.noteList.push(newNote);
        });

        connection.start().done(function () {
            self.connected = true;
            self.resetList();
        });
    };
};

var viewModelInstance = new viewModel();
viewModelInstance.init();
ko.applyBindings(viewModelInstance);