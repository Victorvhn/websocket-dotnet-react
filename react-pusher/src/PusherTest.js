import React from "react";

export default function PusherTest({ messages }) {
  return (
    <div>
      <h1>Hello World!</h1>
      {messages.map(message => (
        <p>{message}</p>
      ))}
    </div>
  );
}
