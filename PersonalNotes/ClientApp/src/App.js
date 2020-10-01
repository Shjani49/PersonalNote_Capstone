import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { HomePage } from './components/HomePage';
import { FetchData } from './components/FetchData';

import './custom.css'
import { CreateNotes } from './components/CreateNotes';
import { ReadNotes } from './components/ReadNotes';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={HomePage} />
            <Route exact path='/read-notes' component={ReadNotes} />
            <Route exact path='/create-notes' component={CreateNotes} />
      </Layout>
    );
  }
}
