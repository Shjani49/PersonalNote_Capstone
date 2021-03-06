import React, { Component } from 'react';
import axios from 'axios';

export class ReadNotes extends Component {
    static displayName = ReadNotes.name;

    constructor(props) {
        // 1) When we build the component, we assign the state to be loading, and register an empty list in which to store our forecasts.
        super(props);
        this.state = { notes: [], loading: true };
    }
    componentDidMount() {
        // 2) When the component mounts, we make the async call to the server to retrieve the API results.
        this.populateNotesData();
    }
    async populateNotesData() {
        // 3) Make the async call to the API.
        // When an async call is made, it "awaits" a response. This means that rather than the server hanging and keeping the "thread" (process) open, it shelves the thread to be picked up when the response comes back.
        // This frees up server resources to do other things in the event the request takes a few seconds (or more, if your internet is straight out of 1995).
        /* // We are awaiting the fetch of weatherforecast. When it returns, assign it to response.
         const response = await fetch('weatherforecast');
         // Then we await the conversion to json and create a promised value for the method
         const data = await response.json();
         // Then we can set the state to the data and stop the loading phase, which will trigger a re-render. 
         this.setState({ forecasts: data, loading: false });
         */
        // Axios replaces fetch(), same concept. Send the response and "then" when it comes back, put it in the state.
        axios.get('API/NotesAPI/AllNotes').then(res => {
            this.setState({ notes: res.data, loading: false });
        });
    }
    render() {
        // 4) When we render, this ternary statement will with print loading, or render the forecasts table depending if the async call has come back yet.
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ReadNotes.renderNotesTable(this.state.notes);
        // Either way we render the title, and a description.
        return (
            <div>
                <h1 id="tabelLabel" >Notes Data</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
    static renderNotesTable(notes) {
        // 5) When the async call comes back, render will call this method rather than rendering "Loading...", which will create our table.
        return (
            <div>
                <div>{notes.map(note =>
                    <p key={note.id}>                      
                        <p>{note.description}</p>
                        <p>{note.date}</p>
                     </p>                     
                )}</div>               
            </div>
        );
    }
}