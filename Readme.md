## DateInfo

DateInfo is a simple CLI tool that outputs info about the day.

### How to Install

Run the following command on your shell

```
dotnet tool install --global DateInfo
```

### How to Run

After installed, the simpler way to call the cli is:

```
dateinfo today
```

It will default for today, and using guessing your locale by the current Culture.

If you're like me, that likes the computer in english but live in Portugal, there is a way to force a specific locale:

```
dateinfo today --locale pt-PT
```

You can also try to see other day other than the current day with `--day` option. The day format is fixed as YYYY-MM-DD.

```
dateinfo today --locale pt-PT --day 2024-06-10
```

### Commands

#### Today

Show some info about today

```
dateinfo today
```

#### Next Holiday

Shows when is the next holiday of the current year

```
datetinfo next
```