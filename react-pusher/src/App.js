import React from "react";
import Pusher from "pusher-js";

export default class App extends React.Component {
  state = {
    messages: []
  };

  componentDidMount = () => {
    const pusher = new Pusher("6d039c28c516b925cfae", {
      cluster: "us2",
      forceTLS: true
    });

    var channel = pusher.subscribe("jiraya");
    channel = channel.bind(this);
    channel.bind(
      "message",
      function(data) {
        this.handleChange(data.message);
      },
      this
    );
  };

  handleChange = message => {
    this.setState({ messages: [...this.state.messages, message] });
  };

  render() {
    return (
      <div>
        {this.state.messages.map(message => (
          <p>{message}</p>
        ))}
      </div>
    );
  }
}
