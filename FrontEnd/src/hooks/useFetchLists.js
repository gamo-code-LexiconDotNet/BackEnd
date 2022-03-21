import { useEffect, useState } from "react";

const useFetchLists = () => {
  const [isLoading, setIsLoading] = useState(true);
  const [data, setData] = useState(null);
  const [fetchError, setFetchError] = useState(null);

  useEffect(() => {
    const abortController = new AbortController();
    setIsLoading(true);

    Promise.all([
      fetch("/api/city/list", { signal: abortController.signal }),
      fetch("/api/language/list", { signal: abortController.signal }),
    ])
      .then(([res1, res2]) => {
        if (!res1.ok || !res2.ok) {
          throw Error("Could not fetch data from that resource");
        }
        return Promise.all([res1.json(), res2.json()]);
      })
      .then(([data1, data2]) => {
        setData({ cities: data1, languages: data2 });
        setIsLoading(false);
        setFetchError(null);
      })
      .catch((err) => {
        if (err.name === "AbortError") {
          console.log("fetch aborted");
        } else {
          setIsLoading(false);
          setFetchError(err.message);
        }
      });
    return () => abortController.abort();
  }, []);

  return { isLoading, data, fetchError };
};

export default useFetchLists;
