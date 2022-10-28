function ExtractInclude ($line)
{
    if ($line  -like  'Content Include=') {
        return $line.Split('')  select -Skip 1  select -First 1
    }
}

function RemoveMissingInclude ([string]$path, [bool]$report) {
    $reader = [System.IO.File]OpenText($path)
    $projectPath = (Split-Path $path) + 

    try {
        for() {
            $line = $reader.ReadLine()
            if ($line -eq $null) { break }

            $pathInclude = ExtractInclude($line)

            if ($report) {
                if ($pathInclude -ne ) {
                    if (-not (Test-Path $projectPath$pathInclude)) { $pathInclude }
                } 
            } else {
                if ($pathInclude -ne ) {
                    if (Test-Path $projectPath$pathInclude) { $line }
                } else {
                    $line
                }
           }
        }
    }
    finally {
        $reader.Close()
    }
}