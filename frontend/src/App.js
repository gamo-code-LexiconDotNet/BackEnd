import React, { Component } from 'react';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { testData: [], loading: true };
    }

    componentDidMount() {
        this.getTest();
    }

    static renderTestData(testData) {
      return (
            <p></p>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p>Loading...</p>
            : App.renderTestData(this.state.testData);

        return (
            <div>
                <h1>Testing backend</h1>
                {contents}
            </div>
        );
    }

    async getTest() {
        const response = await fetch('test');
        const data = await response.json();
        this.setState({ testData: data, loading: false });
    }
}
