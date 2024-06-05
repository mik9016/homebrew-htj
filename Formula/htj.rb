class Htj < Formula
  desc "htj - HEIC to JPG Converter"
  homepage "https://github.com/mik9016/homebrew-htj"
  url "https://github.com/mik9016/homebrew-htj/archive/refs/tags/htj_1.1.tar.gz"
  sha256 "a1f3fc10469b1617262a13d738f06aecd0b2d1ec08e194070d68c66daff1a61f"
  license "MIT"

  depends_on "dotnet"

  def install
    bin.install "htj"
  end

  test do
    system "#{bin}/htj", "--version"
  end
end
