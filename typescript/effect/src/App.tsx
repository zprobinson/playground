import { Effect, Stream, pipe } from "effect"
import { useEffect, useRef, useState } from "react"
import "./App.css"
import reactLogo from "./assets/react.svg"
import viteLogo from "/vite.svg"

const useButtonClick = (
  buttonRef: React.RefObject<HTMLButtonElement>,
  onClick: (e: Event) => void
) => {
  useEffect(() => {
    const unsubscribe = pipe(
      Stream.fromEventListener(buttonRef.current!, "click"),
      Stream.tap((event) => Effect.sync(() => onClick(event))),
      Stream.runDrain,
      Effect.runCallback
    )
    return () => unsubscribe()
  }, [buttonRef, onClick])
}

function App() {
  const [count, setCount] = useState(0)
  const buttonRef = useRef<HTMLButtonElement>(null)

  useButtonClick(buttonRef, () => setCount((current) => current + 1))

  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button ref={buttonRef}>count is {count}</button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  )
}

export default App
