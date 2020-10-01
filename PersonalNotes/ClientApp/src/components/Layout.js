import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { Header } from './Header';
import { Footer } from './Footer';

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div>

                <Header/>
                <NavMenu />
                <Container>
                    {this.props.children}
                </Container>
                <Footer/>
            </div>
        );
    }
}
