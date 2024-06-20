import { useState } from 'react';

export default function MyButton() {
  const [count, setCount] = useState(0);

  function handleClick() {
    setCount(count + 1);
  }

  return (
    <container>
      <label >Count:</label>
      <input type="number" name="count" value={count} readonly/>
      <button onClick={handleClick}>
        Click Me
      </button>
    </container>
  );
}