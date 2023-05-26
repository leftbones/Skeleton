# Skeleton
Skeleton is a barebones UI library for use with Raylib-cs that I made in order to have an easy drop-in UI solution for any projects going forward.

It's based entirely on only two elements: Containers and Widgets. Containers hold widgets, and that's pretty much it. There are a few built in widgets, but you can also define your own.

Using an event system, events can be generated and sent to the interface, then all of the active interface elements will check that event and see if they are able to do anything with it.

For example, a Button waits for a `MouseLeftEvent`, and when it receives one, it invokes the stored `Action` assigned to the button. If any elements handle the event, they'll return `true`, so you know not to send that input further into your game, because the interface has already captured it.
