class Htj < Formula
  desc "htj - HEIC to JPG Converter"
  homepage "https://github.com/mik9016/homebrew-htj"
  url "https://github.com/mik9016/homebrew-htj/archive/refs/tags/htj_1.1.tar.gz"
  sha256 "c714c7f47e1237ecf74343db84901707d3c63ed68efd1d570d678d1c4160f9a8"
  license "MIT"

  depends_on "dotnet"

  def install
    bin.install "htj"
  end

  test do
    system "#{bin}/htj", "--version"
  end
end
